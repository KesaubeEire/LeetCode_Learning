public class 命名工具
{
	public static void main(String[] args)
	{
		System.out.println("这里是命名!!!");
		char[] a = Console.ReadLine().ToCharArray();
		char[] b = new char[a.length + 1];
		b[0] = '_';

		for (int i = 0; i < a.length; i++)
		{
			if (a[i] == ' ' || a[i] == '.')
				a[i] = '_';
			b[i + 1] = a[i];
		}

		foreach (var VARIABLE in b)
		{
			Console.Write(VARIABLE);
		}

	}
}
