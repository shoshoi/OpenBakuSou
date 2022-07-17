# OpenBakuSou
本ソフトウェアはゲーム実況者「幕末志士」を元ネタにした二次創作音楽ゲーム「幕奏-BAKU SOU-」のオープンソース版です。
画像ファイルや音声ファイルを差し替えて、独自の音楽ゲームを作成することができます。

![Help Image](Assets/Images/help.png)

- [「幕奏-BAKU SOU-」のPV](https://www.youtube.com/watch?v=36_LHk08OWA)
- [「幕奏-BAKU SOU-」のトレーラー](https://www.youtube.com/watch?v=LSZIk9C3c5Q)

[元バージョンはBOOTHにて配布しています。](https://jirko.booth.pm/items/4003586)

# 本ソフトウェア使用のガイドライン
以下に本ソフトウェア使用のガイドラインを記載します。詳細につきましてはLICENSEファイルを参照ください。

## できること
- 本ソフトウェアを複製、改造し、Assets\Images配下の画像ファイルを差し替えた上で公開、頒布すること

## できないこと
- 本ソフトウェア（または本ソフトウェアを基に作成した著作物）を著作者（shoshoi）の許可なく販売すること  
　→商用利用は想定しておりません。

- Assets\Images 配下の画像ファイル(*.png)を差し替えずにソフトウェアを配布すること  
　→Assets\Images 配下の画像ファイルの著作権は[オ田](https://twitter.com/ohda_ooda)に帰属します。私的使用の範囲を超えて使用することはできません。

## 注意すべきこと
- Assets\Resources 配下の画像ファイルおよび音声ファイル(*.wav)の著作権は[幕末志士](https://twitter.com/kirizaki_ei)に帰属します。これらの画像ファイルおよび音声ファイルは[「幕末志士」切り抜きガイドライン](https://bakuon.xsrv.jp/guideline_kirinuki.html)に従って、使用者の責任のもと使用できます。ソフトウェア作者は使用によって生じる一切の損害について責任を負いかねますのでご了承ください。

# 開発環境
- Unity 2020.3.26f
- ruby 3.1.2

# 使用ソフト・ライブラリ
- [FancyScrollView](https://github.com/setchi/FancyScrollView)  
　→メニュー画面のアニメーション実装に使用しています。
- [NoteEditor](https://github.com/setchi/NoteEditor)  
　→楽曲の譜面制作に使用しています。

# OpenBakuSou 開発手順
## 1.画像を差し替える（必須）
### **※（必須）以下の画像は差し替え必須です**
| # | ファイル名 | 概要 | 表示される条件 |
| :---: | :--- | :--- | :--- |
| 1 | Assets\Images\help.png | ヘルプ画像 | メニュー画面でヘルプボタン押下時 |
| 3 | Assets\Images\sai1.png | ゲーム画面左側に表示されるキャラクターイラスト | スコア評価がCランクのとき |
| 4 | Assets\Images\sai2.png | ゲーム画面左側に表示されるキャラクターイラスト | スコア評価がBランクのとき |
| 5 | Assets\Images\sai3.png | ゲーム画面左側に表示されるキャラクターイラスト | スコア評価がAランクのとき |
| 6 | Assets\Images\sai4.png | ゲーム画面左側に表示されるキャラクターイラスト | スコア評価がSランクのとき |
| 7 | Assets\Images\saka1.png | ゲーム画面右側に表示されるキャラクターイラスト | スコア評価がCランクのとき |
| 8 | Assets\Images\saka2.png | ゲーム画面右側に表示されるキャラクターイラスト | スコア評価がBランクのとき |
| 9 | Assets\Images\saka3.png | ゲーム画面右側に表示されるキャラクターイラスト | スコア評価がAランクのとき |
| 10 | Assets\Images\saka4.png | ゲーム画面右側に表示されるキャラクターイラスト | スコア評価がSランクのとき |
| 11 | Assets\Images\top.png | トップ画面の扉絵 | トップ画面表示時 |

### （任意）以下の画像は差し替え**任意**です
| # | ファイル名 | 概要 | 表示される条件 |
| :---: | :--- | :--- | :--- |
| 1 | Assets\Textures\rank\a.png | リザルト画面のAランク画像 | Aランクのとき |
| 1 | Assets\Textures\rank\b.png | リザルト画面のBランク画像 | Bランクのとき |
| 1 | Assets\Textures\rank\c.png | リザルト画面のCランク画像 | Cランクのとき |
| 1 | Assets\Textures\rank\s.png | リザルト画面のSランク画像 | Sランクのとき |
| 1 | Assets\Textures\rank\ss.png | リザルト画面のSSランク画像 | SSランクのとき |
| 1 | Assets\Textures\score\0.png～9.png | リザルト画面のスコアの数字 | リザルト画面表示時 |
| 1 | Assets\Textures\score\newrecord.png | リザルト画面でニューレコード達成時 | ニューレコード達成時 |
| 1 | Assets\Textures\score\score.png | リザルト画面のスコアテキスト | リザルト画面表示時 |
| 1 | Assets\Textures\bar_clear.png | ゲーム画面のスコアバーのクリア部分 | ゲーム画面表示時 |
| 1 | Assets\Textures\bar_fail.png | ゲーム画面のスコアバーの失敗部分 | ゲーム画面表示時 |
| 1 | Assets\Textures\bar_image.png | ゲーム画面のスコアバーの枠 | ゲーム画面表示時 |
| 1 | Assets\Textures\bgkinoko.png | ゲーム画面の奥に表示される黒のきのこマーク | ゲーム画面表示時 |
| 1 | Assets\Textures\char1.png | ゲーム画面の手前に表示されるノーツマーク | ゲーム画面表示時 |
| 1 | Assets\Textures\char1_shadow.png | ゲーム画面の奥から流れてくるノーツマーク | ゲーム画面表示時 |
| 1 | Assets\Textures\char2.png | 未使用 | 未使用 |
| 1 | Assets\Textures\charhikari.png | ゲーム画面の手前に表示されるノーツマーク押下時のエフェクト | ゲーム画面表示時 |
| 1 | Assets\Textures\FillGreen.png | メニュー画面の設定ウィンドウの音量設定バーの背景 |メニュー画面でSetting押下時 |
| 1 | Assets\Textures\pushGreen.png | ゲーム画面でノーツ押下時、判定がGreatのとき | 判定がGreatのとき |
| 1 | Assets\Textures\pushMizu.png | ゲーム画面でノーツ押下時、判定がGoodのとき | 判定がGoodのとき |
| 1 | Assets\Textures\pushMura.png | ゲーム画面でノーツ押下時、判定がBadのとき | 判定がBadのとき |
| 1 | Assets\Textures\pushNotes.png | ゲーム画面でノーツ押下時、未判定のとき | 未判定のとき |
| 1 | Assets\Textures\pushRed.png | 未使用 | 未使用 |
| 1 | Assets\Textures\star.png | リザルト画面のアイコン | リザルト画面表示時 |

## 2.効果音・BGM・ボイスを差し替える（任意）
### 効果音
| # | ファイル名 | 概要 | 流れる条件 |
| :---: | :--- | :--- | :--- |
| 1 | Assets\Sounds\choice.wav | メニュー画面の楽曲選択効果音 | メニュー画面で楽曲のスクロール選択時 |
| 2 | Assets\Sounds\clap.wav | ゲーム画面のノーツ押下効果音 | ゲーム画面でノーツ押下時 |
| 3 | Assets\Sounds\result_BGM.wav | リザルト画面のBGM | リザルト画面表示時 |
| 4 | Assets\Sounds\top_BGM.wav | トップ画面のBGM | トップ画面表示時 |
| 5 | Voices\end\clear.wav | ゲーム画面のゲームクリア時効果音 | ゲームクリアの時 |
| 6 | Voices\end\fail.wav | ゲーム画面のゲーム失敗時効果音 | ゲーム失敗の時 |
| 7 | Voices\toubakumania\enter.wav | メニュー画面で特殊仕様譜面を選んだ時の効果音 | 特殊仕様楽曲の選択時 |
| 8 | Voices\toubakumania\start.wav | ゲーム画面で特殊仕様譜面開始時の効果音 | 特殊仕様楽曲の選択時 |

以下は、ディレクトリ配下の`.wav`ファイルがランダムで流れる仕様となっています。  
| # | ディレクトリ名 | 概要 | 流れる条件 |
| :---: | :--- | :--- | :--- |
| 1 | Voices\start\\*.wav | ゲーム画面でゲーム開始時のボイス  | ゲーム開始時 |
| 2 | Voices\enter\\*.wav | メニュー画面で楽曲を選んだ時のボイス | 楽曲を選んだ時 |
| 3 | Voices\game\B\\*.wav | ゲーム画面でスコアがB評価に達した時のボイス | スコアがB評価に達した時 |
| 4 | Voices\game\A\\*.wav | ゲーム画面でスコアがA評価に達した時のボイス | スコアがA評価に達した時 |
| 5 | Voices\game\S\\*.wav | ゲーム画面でスコアがS評価に達した時のボイス | スコアがS評価に達した時 |
| 6 | Voices\clear\\*.wav | リザルト画面でゲームクリア時のボイス | ゲームクリア時 |
| 7 | Voices\fail\\*.wav | リザルト画面でゲーム失敗時のボイス | ゲーム失敗時 |

## 3.楽曲を差し替える・追加する（任意）
### 3.1 楽曲データの概要
楽曲データは`Assets\Resources\Music`配下に配置します。楽曲データは1つのディレクトリと、その配下のファイルで構成されます。  
ディレクトリ名は`00_musicname`（先頭2桁はディレクトリ内で一意のID、musicnameは任意の名前）です。  
配下のファイルは以下の通りです。
| # | ファイル名 | 内容 |
| :---: | :--- | :--- |
| 1 | image.png | ジャケット画像です。縦横比は1:1です |
| 2 | info.json | 楽曲のタイトルや作者などの情報を記載します |
| 3 | music.wav | ゲームで再生される音楽データです |
| 4 | preview.wav | メニュー画面でプレビューされる音楽データです |
| 5 | score.json | 譜面データです |

### 3.2 ジャケット画像(image.png)の準備
ジャケット画像を準備します。画像の縦横比を1:1にリサイズして、`image.png`という名前で保存します。

### 3.3 楽曲情報(info.json)の準備
楽曲情報を以下のjson形式で作成します。`info.json`という名前で保存します。

| # | キー | 型 | 内容 |
| :---: | :--- | :--- | :--- |
| 1 | title | string | タイトル |
| 2 | artist | string | アーティスト名 |
| 3 | arranger | string | 編曲者名 |
| 4 | author | string | 譜面の作者名 |
| 5 | level | int | 譜面の難易度(*1) |
| 6 | score_ver | int | 譜面ファイルのバージョン(*2) |
| 7 | date | int | 楽曲の公開日 |
| 8 | type | int | 楽曲のタイプ(*3) |
| 9 | genre | int | 楽曲のジャンル(*4) |

`info.json`の例を以下に示します。
```
{
    "title":"蝦夷のセレナーデ",
    "artist":"幕末志士",
    "arranger":"Jirno",
    "author":"Jirno",
    "level":4,
    "score_ver":1,
    "date":"2016-01-20",
    "type":"arrange",
    "genre":"nicolive"
}

```
#### ***1 : 譜面の難易度の設定値**
譜面の難易度は[3.7 楽曲データの譜面の難易度設定](#37-楽曲データの譜面の難易度設定)で自動計算します。  
ここでは仮の数値を設定してください。

#### ***2 : score_verの設定値**
譜面のバージョンです。通常は`1`を指定します。  
譜面のバージョンの詳細については[3.6 譜面データの準備](#36-譜面データの準備)で説明します。

| # | 値 | 概要 |
| :---: | :--- | :--- |
| 1 | 0 | 旧形式の譜面 |
| 2 | 1 | 新形式の譜面 |

#### ***3 : typeの設定値**
楽曲のタイプです。メニュー画面での楽曲のソートに使用します。
| # | 値 | 概要 |
| :---: | :--- | :--- |
| 1 | "original" | オリジナル楽曲 |
| 2 | "arrange" | アレンジ楽曲 |

#### ***4 : genreの設定値**
楽曲のジャンルです。メニュー画面での楽曲のソートに使用します。
| # | 値 | 概要 |
| :---: | :--- | :--- |
| 1 | "nicovideo" | ニコニコ動画で公開された曲 |
| 2 | "nicolive" | ニコニコ生放送で公開された曲 |
| 3 | "etc" | その他の曲 |

### 3.4 音楽データの準備
音楽データを準備します。形式は`*.wav`です。  
音楽がBPMと同期するよう先頭の無音を調整しておくと、後の譜面作成の手順が楽になります。

### 3.5 音楽プレビューデータの準備
音楽プレビューデータを準備します。形式は`*.wav`です。  
メニュー画面で楽曲を選んだ時にプレビュー再生されます。目安として`30秒前後`の長さで、前後をフェードイン・フェードアウトするといい感じに再生されます。

### 3.6 譜面データの準備
BakuSouでは、@setchiさんが制作された[NoteEditor](https://github.com/setchi/NoteEditor)で譜面データを作成します。  
[NoteEditor](https://github.com/setchi/NoteEditor)で作成した譜面データをOpenBakuSouでは`バージョン1`の譜面データとします。バージョン1の譜面データの仕様についてはここでは割愛します。詳細は[NoteEditor](https://github.com/setchi/NoteEditor)の実装をご確認ください。

[NoteEditor](https://github.com/setchi/NoteEditor)で譜面を保存すると、読み込んだwavファイルのあるディレクトリの1階層上に、`Notes`という名前のディレクトリが作られ、その配下に`wavファイルの名前.json`という名前で譜面データが出力されます。
この譜面データを楽曲データディレクトリにコピーし、コピーした譜面データの名前を`score.json`にリネームしてください。


**補足：`バージョン0`の譜面データについて**  
OpenBakuSouでは、以下の形式の譜面データも使用することができます。  
この譜面データの形式をOpenBakuSouでは`バージョン0`とします。

`バージョン0`の譜面データの形式は以下の通りです。
| # | キー | 型 | 内容 |
| :---: | :--- | :--- | :--- |
| 1 | timing | 配列(double) | ノーツのタイミング |
| 2 | key | int | ノーツ番号(0から4に向かって左から右) |
| 3 | bpm | int | 楽曲のBPM |

`バージョン0`の譜面データの例を以下に示します。
```
{
  "timing": [4.144,4.634,4.634,4.909,5.075],
  "key": [2,0,4,1,3],
  "bpm": 125
}
```
この譜面の場合、一番最初に出現するノーツを押すタイミングは`timing[0]`(4.144秒)で、押下するキーは`key[0]`(2=左から3番目のキー)となります。

### 3.7 楽曲データの譜面の難易度設定
1. `Assets\Resources\Music`配下に上記で作成した`00_musicname`（楽曲データ）をコピーします。
2. コマンドプロンプトを開き、カレントディレクトリを`Assets\Resources\Music`に移動します。
3. 以下のコマンドを実行します。（rubyの実行環境が必要です。）
```
ruby level_calc.rb
```
上記コマンドを実行することで、`Assets\Resources\Music`配下の楽曲情報(`info.json`)の譜面の難易度を、譜面の密度やBPMから自動で計算し上書き更新します。

### 3.8 楽曲データの組み込み
1. コマンドプロンプトを開き、カレントディレクトリを`Assets\Resources\Music`に移動します。
2. 以下のコマンドを実行します。（rubyの実行環境が必要です。）
```
ruby list_generate.rb
```
`Assets\Resources\Music\list.json`の内容が更新され、ゲーム上で楽曲が認識されるようになります。

## ビルド
Unityのメニューバーの File > Build And Run からビルドしてください。