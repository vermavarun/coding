// See https://aka.ms/new-console-template for more information

DisplayOneByOne();
DisplayZeroByZero();
ToggleBit();

static void ToggleBit() {
    int num = 55;
    DecimalToBinary(num);
    num ^= (1 << 2); // ToggleBit 2 is position num is number in decimal
    DecimalToBinary(num);
    Console.WriteLine(num);
}

static void DisplayOneByOne() {
    int a = 1;
    string binary = string.Empty;
    int loopCounter = 1;
    while(loopCounter < 10) {

        binary = DecimalToBinary(a);
        a = Convert.ToInt32(binary,2);
        a = a | (1 << loopCounter); // set bit

        loopCounter = loopCounter + 1;
    }
}


static void DisplayZeroByZero() {
    int a = 511;
    string binary = string.Empty;
    int loopCounter = 10;
    while(loopCounter > 0) {

        binary = DecimalToBinary(a);
        a = Convert.ToInt32(binary,2);
        a = a & (~(1 << loopCounter)); //unset bit

        loopCounter = loopCounter - 1;
    }
}

static string DecimalToBinary(int decVal) {
    int val;
    string a = "";
    Console.WriteLine("Decimal: {0}", decVal);
    while (decVal >= 1)
    {
        val = decVal / 2;
        a += (decVal % 2).ToString();
        decVal = val;
    }
    string binValue = "";
    for (int i = a.Length - 1; i >= 0; i--)
    {
        binValue = binValue + a[i];
    }
    Console.WriteLine("Binary: {0}", binValue);
    return binValue;
}
