
public   class Program
{

	int n, m;

	   public static  int[] fa;
	  public static  int[] pf ;
	 public static   int[] cnt;

	 public int find(int x)
	 {
		 if (fa[x] == -1) return x;
		 return fa[x] = find(fa[x]);
	 }
	 public boolean valid(int x, int y)
	 {
		 return x >= 0 && x < n && y >= 0 && y < m;
	 }



	public int[] hitBricks(int[][] grid, int[][] hits)
	{

		n = grid.length;
		m = grid[0].length;
		fa=new int[n*m];
		pf = new int[n * m];
		 cnt = new int[n * m];
		
		int[] dx = new int[] { 0, 0, 1, -1 };
		int[] dy = new int[] { 1, -1, 0, 0 };
	
		
		for (int i = 0; i < hits.length; ++i)
		{
			if (grid[hits[i][0]][hits[i][1]]==1) grid[hits[i][0]][hits[i][1]] = 0;
			else hits[i][0] = -1;
		}

	  //  fa.assign(n * m, -1);
	   // pf.assign(n * m, 0);
	  //  cnt.assign(n * m, 1);
		for (int i = 0; i < n*m; i++)
		{
			fa[i] = -1;
			pf[i] = 0;
			cnt[i] = 1;
			
			
		}
		for (int i = 0; i < m; ++i) pf[i] = 1;
		for (int i = 0; i < n; ++i)
			for (int j = 0; j < m; ++j)
			{
				if (grid[i][j]==1)
				{
					int fx = find(i * m + j);
					if (valid(i + 1, j) && grid[i + 1][j]==1)
					{
						int fy = find((i + 1) * m + j);
						if (fx != fy)
						{
							cnt[fx] += cnt[fy];
							pf[fx] = pf[fy] = pf[fx] | pf[fy];
							fa[fy] = fx;
						}
					}
					if (valid(i, j + 1) && grid[i][j + 1]==1)
					{
						int fy = find(i * m + j + 1);
						if (fx != fy)
						{
							cnt[fx] += cnt[fy];
							pf[fx] = pf[fy] = pf[fx] | pf[fy];
							fa[fy] = fx;
						}
					}
				}
			}

	  //  vector<int> res = vector<int>(hits.size(), 0);
		int[]res=new int[hits.length];
		for (int i = hits.length - 1; i >= 0; --i)
		{
			if (hits[i][0] == -1) continue;
			int x = hits[i][0];
			int y = hits[i][1];
			int a = find(x * m + y);
			int d = 0;
			for (int j = 0; j < 4; ++j)
			{
				int nx = x + dx[j];
				int ny = y + dy[j];
				if (valid(nx, ny) && grid[nx][ny]==1)
				{
					int b = find(nx * m + ny);
					if (a == b) continue;
				   // if (!pf[b]) d += cnt[b];
					if (pf[b]!=1) d += cnt[b];

					cnt[a] += cnt[b];
					pf[a] = pf[b] = pf[a] | pf[b];
					fa[b] = a;
				}
			}
			grid[x][y] = 1;
			if (pf[a]==1) res[i] = d;
		}
		return res;

	}
	
	public static void main(String[] args)
	{
		int[][] grid = new int[2][];
		int[][] hits = new int[1][];
		grid[0] = new int[] { 1, 0, 0, 0 };
		grid[1] = new int[] { 1, 1, 1, 0 };
		hits[0] = new int[] { 1, 0 };
		showData(new Program().hitBricks(grid, hits));
		System.out.println("============");
		grid = new int[2][];
		hits = new int[2][];
		grid[0] = new int[] { 1, 0, 0, 0 };
		grid[1] = new int[] { 1, 1, 0, 0 };
		hits[0] = new int[] { 1, 1 };
		hits[1] = new int[] { 1, 0 };
		showData(new Program().hitBricks(grid, hits));



		
	}

	private static void showData(int[] p)
	{
		//throw new NotImplementedException();
		for (int item:p)
		{
			System.out.printf("%d ", item);
		}
		System.out.println();

	}

}
