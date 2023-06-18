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

// ピザ注文システム
public class Pizza{
  public string variation;
  public int[] value;
  public int[] stock;

  public Pizza(string variation, int[] value, int[] stock){
    this.variation = variation;
    this.value = value;
    this.stock = stock;
  }

  public void orderTaking(int size, int order){
    this.stock[size] -= order;
  }

  public void addStock(int size, int add){
    this.stock[size] += add;
    string sizeStr = "";
    switch(size){
      case 0:
        sizeStr = "S";
        break;
      case 1:
        sizeStr = "M";
        break;
      case 2:
        sizeStr = "L";
        break;
    }
    Console.WriteLine($"{this.variation}{sizeStr}を{add.ToString()}枚追加しました。");
  }

  public void checkStock(){
    Console.WriteLine($"{this.variation} S: {this.stock[0].ToString()}");
    Console.WriteLine($"{this.variation} M: {this.stock[1].ToString()}");
    Console.WriteLine($"{this.variation} L: {this.stock[2].ToString()}");
  }
}

Task("pizza")
.Does(() =>{
  Pizza[] pizzaArray = new Pizza[3];
  pizzaArray[0] = new Pizza("マルゲリータ", new int[] {1200, 1500, 1800}, new int[] {0, 1, 2});
  pizzaArray[1] = new Pizza("ペパロニピザ", new int[] {1100, 1400, 1700}, new int[] {3, 4, 5});
  pizzaArray[2] = new Pizza("ミソスープピザ", new int[] {120, 150, 180}, new int[] {6, 7, 8});

  string input = "";
  while(true){
    Console.WriteLine("ピザ注文システム");
    Console.WriteLine();
    Console.WriteLine("何をするか番号を入力してください。");
    Console.WriteLine("1. 注文受付");
    Console.WriteLine("2. 在庫確認");
    Console.WriteLine("3. 在庫追加");
    Console.WriteLine("4. 終了");
    Console.WriteLine();
    Console.Write("番号を入力：");
    input = Console.ReadLine();
    Console.WriteLine("");
    Console.WriteLine("------------------------------");
    Console.WriteLine("");
    
    if(input == "4"){
      break;
    }
    switch(input){
      case "1":
        // 注文受付画面
        orderTaking(pizzaArray);
        break;
      case "2":
        // 在庫確認画面
        checkStock(pizzaArray);
        break;
      case "3":
        // 在庫追加画面
        addStock(pizzaArray);
        break;
      default:
        Console.WriteLine("有効な値を入力してください。");
        Console.WriteLine("");
        Console.WriteLine("------------------------------");
        Console.WriteLine("");
        break;
    }
  }

  Console.WriteLine("終了しました。");

});

void orderTaking(Pizza[] pizzaArray){
  string input = "";
  bool isInt = false;
  bool isBreak = false;
  
  int total = 0;

  while(true){
    if(isBreak){
      if(total > 0){
        Console.WriteLine($"合計金額は{total}円です。");
        Console.WriteLine("");
        Console.Write("確認（Enter）");
        Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("------------------------------");
        Console.WriteLine("");
      }
      break;
    }
    
    Console.Write("ピザの名前を入力してください：");
    input = Console.ReadLine();
    int variationInt = 0;
    bool isVariation = false;
    foreach(Pizza pizza in pizzaArray){
      if(pizza.variation == input){
        isVariation = true;
        break;
      }
      variationInt += 1;
    }
    if(isVariation == false){
      Console.WriteLine("");
      Console.WriteLine("------------------------------");
      Console.WriteLine("");
      Console.WriteLine("有効な値を入力してください。");
      Console.WriteLine("");
      isBreak = isOrderFinish();
      continue;
    }

    int sizeInt = 0;
    Console.Write("サイズを入力してください：");
    input = Console.ReadLine();

    switch(input){
      case "s":
      case "S":
        break;
      case "m":
      case "M":
        sizeInt = 1;
        break;
      case "l":
      case "L":
        sizeInt = 2;
        break;
      default:
        Console.WriteLine("");
        Console.WriteLine("------------------------------");
        Console.WriteLine("");
        Console.WriteLine("有効な値を入力してください。");
        Console.WriteLine("");
        isBreak = isOrderFinish();
        continue;
    }
    

    Console.Write("枚数を入力してください：");
    input = Console.ReadLine();
    int orderInt = 0;
    isInt = int.TryParse(input, out orderInt);
    if(isInt && 0 < orderInt && orderInt < 1000000 ){
      if(orderInt <= pizzaArray[variationInt].stock[sizeInt]){
        pizzaArray[variationInt].orderTaking(sizeInt, orderInt);
        total += pizzaArray[variationInt].value[sizeInt] * orderInt;
      }
      else{
        Console.WriteLine("");
        Console.WriteLine("------------------------------");
        Console.WriteLine("");
        Console.WriteLine("在庫が足りません。");
        Console.WriteLine("");
        isBreak = isOrderFinish();
        continue;
      }
    }
    else{
      Console.WriteLine("");
      Console.WriteLine("------------------------------");
      Console.WriteLine("");
      Console.WriteLine("有効な値を入力してください。");
      Console.WriteLine("");
        isBreak = isOrderFinish();
      continue;
    }

    isBreak = isOrderFinish();
    if(isBreak == false){
      continue;
    }

    isBreak = true;
  }
}

bool isOrderFinish(){
  string input = "";
  bool isBreak = false;
  while(true){
    Console.WriteLine("注文を追加する場合は1,終了する場合は0");
    Console.Write("番号を入力：");
    input = Console.ReadLine();
    Console.WriteLine("");
    Console.WriteLine("------------------------------");
    Console.WriteLine("");
    switch(input){
      case "0":
        isBreak = true;
        break;
      case "1":
        isBreak = false;
        break;
      default:
        Console.WriteLine("有効な値を入力してください。");
        Console.WriteLine("");
        Console.WriteLine("------------------------------");
        Console.WriteLine("");
        continue;
    }
    break;
  }

  return(isBreak);
}

void checkStock(Pizza[] pizzaArray){
  foreach(Pizza pizza in pizzaArray){
    pizza.checkStock();
  }
  Console.WriteLine("");
  Console.WriteLine("------------------------------");
  Console.WriteLine("");
  Console.Write("確認（Enter）");
  Console.ReadLine();
  Console.WriteLine("");
  Console.WriteLine("------------------------------");
  Console.WriteLine("");
}

void addStock(Pizza[] pizzaArray){
  string input = "";
  bool isInt = false;

  while(true){
    Console.WriteLine("在庫を追加するピザを選んでください。");
    int i = 1;
    foreach(Pizza pizza in pizzaArray){
      Console.WriteLine($"{i}.{pizza.variation}");
      i += 1;
    }
    Console.WriteLine("0.メニューに戻る");
    Console.Write("番号を入力：");
    input = Console.ReadLine();
    Console.WriteLine("");
    Console.WriteLine("------------------------------");
    Console.WriteLine("");
    if(input == "0"){
      break;
    }
    int variationInt = 0;
    isInt = int.TryParse(input, out variationInt);
    if(isInt && 0 < variationInt && variationInt < i){
      variationInt -= 1;
      Console.WriteLine($"追加するピザ： {pizzaArray[variationInt].variation}");
    }
    else{
      Console.WriteLine("有効な値を入力してください。");
      Console.WriteLine("");
      Console.WriteLine("------------------------------");
      Console.WriteLine("");
      continue;
    }

    int sizeInt = 0;
    Console.Write("サイズを入力してください：");
    input = Console.ReadLine();

    switch(input){
      case "s":
      case "S":
        break;
      case "m":
      case "M":
        sizeInt = 1;
        break;
      case "l":
      case "L":
        sizeInt = 2;
        break;
      default:
        Console.WriteLine("有効な値を入力してください。");
        Console.WriteLine("");
        Console.WriteLine("------------------------------");
        Console.WriteLine("");
        continue;
    }

    Console.Write("枚数を入力してください：");
    input = Console.ReadLine();
    int addInt = 0;
    isInt = int.TryParse(input, out addInt);
    if(isInt && 0 < addInt && addInt < 1000000){
      pizzaArray[variationInt].addStock(sizeInt, addInt);
    }
    else{
      Console.WriteLine("有効な値を入力してください。");
      Console.WriteLine("");
      Console.WriteLine("------------------------------");
      Console.WriteLine("");
      continue;
    }

    Console.WriteLine("");
    Console.WriteLine("------------------------------");
    Console.WriteLine("");
    Console.Write("確認（Enter）");
    Console.ReadLine();
    Console.WriteLine("");
    Console.WriteLine("------------------------------");
    Console.WriteLine("");

    break;
  }
}

// 指定されたターゲットの実行。必須
RunTarget(target);