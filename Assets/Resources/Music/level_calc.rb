require "json"

def get_note_per_second(file_name)
  hash = Hash.new
  File.open(file_name) do |j|
    begin
      str = j.read.to_s
      str.force_encoding("UTF-8")
      str = str.gsub(/\xEF\xBB\xBF|\xEF\xBF\xBE/,"")
      hash = JSON.parse(str)
    rescue
      return "error"
    end
  end

  if timing = hash["timing"]
    key = hash["key"] 

    first_sec = timing.first.to_f
    last_sec = timing.last.to_f
    return {"file":file_name, "syosetu": nil, "level": ((key.length / (last_sec - first_sec)) * 1.0 ).to_i }
  end

  bpm = hash["BPM"]

  mitudo = Hash.new
  hash["notes"].each do |note|
    lpb = note["LPB"]
    num = note["num"]
    syosetu = num / (lpb * 4)
    unless mitudo[syosetu.to_s]
      mitudo[syosetu.to_s] = 0
    end
    mitudo[syosetu.to_s] += 1
  end
  first_syosetu = mitudo.keys.first.to_f
  last_syosetu = mitudo.keys.last.to_f
  syosetu = last_syosetu + 1 - first_syosetu
  byou = (60.0 / bpm.to_f) * 4.0 * syosetu
  sum = 0;
  mitudo.values.each do |value|
    sum += value.to_i
  end
  {"file":file_name, "syosetu": sum / syosetu , "byou": sum / byou, "level": (((sum / syosetu / 2 + sum / byou) * 1.0) * 1.0).to_i }
end
def initialize_json(file_name)
  hash = Hash.new
  File.open(file_name) do |j| 
    begin
      str = j.read.to_s
      str.force_encoding("UTF-8")
      str = str.gsub(/\xEF\xBB\xBF|\xEF\xBF\xBE/,"")
      hash = JSON.parse(str)
    rescue
      return "error"
    end 
  end 
  hash["level"] = 0 if hash["level"].nil?
  hash["type"] = "original" if hash["type"].nil?
  hash["genre"] = "nicomovie" if hash["genre"].nil?
  begin
    json =  hash.to_json
    puts json
    File.open(file_name, "w") do |f| 
      f.puts(json)
    end 
  rescue => message
    puts message
  end 
end
def set_level(file_name, level)
  hash = Hash.new
  File.open(file_name) do |j| 
    begin
      str = j.read.to_s
      str.force_encoding("UTF-8")
      str = str.gsub(/\xEF\xBB\xBF|\xEF\xBF\xBE/,"")
      hash = JSON.parse(str)
    rescue
      return "error"
    end 
  end
  hash["level"] = level
  begin
    json =  hash.to_json
    puts json
    File.open(file_name, "w") do |f| 
      f.puts(json)
    end
  rescue => message
    puts message
  end
end
items = []
Dir.foreach('.').map do |item|
  if File::ftype(item) == "directory"
    next if item == ".." || item == "."
    hash = Hash.new
    result = get_note_per_second("#{item}/score.json")
    initialize_json("#{item}/info.json")
    items.push result
    puts result
    if result.class.to_s == "Hash"
      if ARGV[0] != nil && item == ARGV[0] && File.exists?("#{item}/info.json")
        set_level("#{item}/info.json", result[:level])
        puts "update : #{item}/info.json"
      end
    end
  end
end
items.reject!{|item| item.class.to_s != "Hash" }
items.sort! do |a, b|
  a[:level] <=> b[:level]
end
puts ""
items.each do |item|
  puts item
end
