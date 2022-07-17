require "json"
list = Dir.foreach('.').map do |item|
  if File::ftype(item) == "directory"
    item
  end
end
list.delete(".")
list.delete("..")
list.compact!
list.sort!

id = 0
list.map! do |item|
  id += 1
  {id: id, path: item }
end

hash = Hash.new
hash[:items] = list
puts hash.to_json
