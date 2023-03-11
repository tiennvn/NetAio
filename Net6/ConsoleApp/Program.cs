using System.Net;

class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo HttpListener
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://lcalhot:8080/");

        // Bắt đầu lắng nghe yêu cầu
        listener.Start();
        Console.WriteLine("Server is running at http://localhost:8080/");

        while (true)
        {
            // Chấp nhận yêu cầu
            HttpListenerContext context = listener.GetContext();

            // Xử lý yêu cầu và gửi phản hồi
            string responseString = "<html><body><h1>Hello, world!</h1></body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();
        }
    }
}