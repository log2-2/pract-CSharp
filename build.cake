// パラメーター設定
// 第一引数が名前、第二引数がデフォルト値
string target = Argument("Target", "Default");

// 動作確認用のタスク
Task("Default")
.Does(() =>
{
  Information("Hello World");
});

// 変数とデータ型
Task("variable")
.Does(() =>
{
  string name = "Enishi Tsuda";
  int age = 21;
  bool isAdult = true;
  string[] color = {"purple", "lightblue", "lightgreen"};

  Console.WriteLine("name ->" + name);
  Console.WriteLine("age ->" + age.ToString());
  Console.WriteLine("isAdult ->" + isAdult.ToString());
  Console.WriteLine("color ->" + color[0] + ", " + color[1] + ", " + color[2]);
});

// 演算子
Task("operator")
.Does(() =>
{
  Information("operator");
});

// if文
Task("if")
.Does(() =>
{
  Information("if");
});

// switch文
Task("switch")
.Does(() =>
{
  Information("switch");
});

// for文
Task("for")
.Does(() =>
{
  Information("for");
});

// while文
Task("while")
.Does(() =>
{
  while (true){
    Console.Write("Input: ");
    string input = Console.ReadLine();
    if(input == "exit"){
      break;
    }
    Console.WriteLine(input);
  }
});

// 例題１
Task("exampleQuestion1")
.Does(() =>{
  // 約数を調べる
  for(int i = 1; i <= 100; i++){
    string output = "";
    if(i % 3 == 0){
      output += "Fizz";
    }
    if(i % 5 == 0){
      output += "Buzz";
    }
    if(output == ""){
      output = i.ToString();
    }

    // 出力
    Console.WriteLine(output);
  }
});

// 例題２
Task("exampleQuestion2")
.Does(() =>{
  // 入力
  Console.Write("Enter a number from 1 to 7: ");
  string input = Console.ReadLine();

  
  // 入力値を曜日に変換
  string[] day = new string[] {"月", "火", "水", "木", "金", "土", "日"};
  string output = "Invalid input.";
  switch (input){
    case "1":
    case "2":
    case "3":
    case "4":
    case "5":
    case "6":
    case "7":
      output = day[int.Parse(input) - 1] + "曜日";
      break;
  }

  // 出力
  Console.WriteLine(output);
});

// 難問Ｉ
Task("difficultQuestionI")
.Does(() =>{
  // 入力
  string[] STR_NM = Console.ReadLine().Split();
  int STATIONS = int.Parse(STR_NM[0]);
  int BUSES = int.Parse(STR_NM[1]);
  
  // 階差を求める
  int[] kaisa = new int[STATIONS + 1];
  for(int i = 0; i < BUSES; i++){
    string[] STR_LR = Console.ReadLine().Split();
    int start = int.Parse(STR_LR[0]);
    int end = int.Parse(STR_LR[1]);
    kaisa[start - 1] += 1;
    kaisa[end] -= 1;
  }

  // 累積和を求める
  int[] output = new int[STATIONS];
  output[0] = kaisa[0];
  for(int i = 1; i < STATIONS; i++){
    output[i] += output[i - 1] + kaisa[i];
  }

  // 出力
  Console.WriteLine(string.Join(" ", output));
});

// 難問Ｂ
Task("difficultQuestionB")
.Does(() =>{
  // 入力
  // string text = "Onizuka-sensei's morality is great.";
  // string pattern = "great";
  string text = Console.ReadLine();
  string pattern = Console.ReadLine();

  // ずらし表を作成
  Dictionary<string, int> slideList = new Dictionary<string, int>();
  for(int i = 0; i < pattern.Length; i++){
    slideList[pattern[i].ToString()] = pattern.Length - i;
  }

  // 簡略化したボイヤ・ムーア法による探索
  // 本来のボイヤムーア法よりも効率は悪い
  bool isBreak = false;
  int output = -1;
  for(int i = pattern.Length - 1; i < text.Length; i++){
    for(int j = 0; j < pattern.Length; j++){
      // 文字が一致した場合
      if(text[i - j] == pattern[pattern.Length - 1 - j]){
        if(j == pattern.Length - 1){
          output = i - pattern.Length + 1;
          isBreak = true;

          break;
        }
        continue;
      }
      // 文字が一致しない場合
      else{
        int slide = pattern.Length;
        foreach(KeyValuePair<string, int> k in slideList){
          if(k.Key == text[i - j].ToString()){
            slide = k.Value - j - 1;
            break;
          }
        }
        i += slide - 1;
        break;
      }
    }
    if(isBreak){
      break;
    }
  }

  // 出力
  Console.WriteLine(output);
});

// 関数の実行確認用
Task("useSampleFunction")
.Does(() =>
{
  Information("useSampleFunction");
  SampleFunction();
  Console.WriteLine("SampleInt -> " + SampleIntFunction().ToString());
});

Task("function")
.Does(() =>
{
  Information("function");
});

void SampleFunction()
{
  Console.WriteLine("This is SampleFunction");
}

int SampleIntFunction()
{
  return 1;
}

// 指定されたターゲットの実行。必須
RunTarget(target);