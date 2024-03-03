namespace ImageToAsciiArt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a file path of an image");
            ImageToBitmap input = new ImageToBitmap(Console.ReadLine());
            BitmapToAscii output = new BitmapToAscii(input);
            output.run();
            Console.ReadLine();
        }
    }
}
