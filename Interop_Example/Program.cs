using System.Runtime.InteropServices;

//Example sourced from https://dev.to/living_syn/calling-rust-from-c-6hk

try
{
    Console.WriteLine("Enter two numbers");
    string numS = string.Empty;

    while (String.IsNullOrWhiteSpace(numS))
    {
        numS = Console.ReadLine();
    }

    numS = numS?.Replace(", ", " ");
    numS = numS?.Replace(",", " ");

    var nums = numS.Split('\u0020');

    int a;
    int b;

    Int32.TryParse(nums[0], out a);
    Int32.TryParse(nums[1], out b);

    var addedNumbers = add_numbers(a, b);
    Console.WriteLine(addedNumbers);
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine("You messed something up. Don't you feel silly?\n");
    Console.WriteLine(ex.Message);
}

[DllImport("")]//ToDo: Add configurable file path for dll //.\\Rust_Code\\target\\release\\interop_example.dll
static extern Int32 add_numbers(Int32 number1, Int32 number2);