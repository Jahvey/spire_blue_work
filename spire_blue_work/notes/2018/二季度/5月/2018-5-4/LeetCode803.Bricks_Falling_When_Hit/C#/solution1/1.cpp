class Solution {
public:  
    vector<int> fa, pf, cnt;  
    int n, m;  
    int dx[4] = {0, 0, 1, -1};  
    int dy[4] = {1, -1, 0, 0};  
      
    int find(int x)  
    {  
        if(fa[x] == -1) return x;  
        return fa[x] = find(fa[x]);  
    }  
    bool valid(int x, int y)  
    {  
        return x >= 0 && x < n && y >= 0 && y < m;  
    }  
    vector<int> hitBricks(vector<vector<int>>& grid, vector<vector<int>>& hits) {  
        n = grid.size();  
        m = grid[0].size();  
        for(int i = 0; i < hits.size(); ++i)  
        {  
            if(grid[hits[i][0]][hits[i][1]]) grid[hits[i][0]][hits[i][1]] = 0;  
            else hits[i][0] = -1;  
        }  
          
        fa.assign(n * m, -1);  
        pf.assign(n * m, 0);  
        cnt.assign(n * m, 1);  
        for(int i = 0; i < m; ++i) pf[i] = 1;    
        for(int i = 0; i < n; ++i)  
            for(int j = 0; j < m; ++j)  
            {  
                if(grid[i][j])  
                {  
                    int fx = find(i * m + j);  
                    if(valid(i + 1, j) && grid[i + 1][j])  
                    {  
                        int fy = find((i + 1) * m + j);  
                        if(fx != fy)  
                        {  
                            cnt[fx] += cnt[fy];  
                            pf[fx] = pf[fy] = pf[fx] | pf[fy];  
                            fa[fy] = fx;  
                        }  
                    }  
                    if(valid(i, j + 1) && grid[i][j + 1])  
                    {  
                        int fy = find(i * m + j + 1);  
                        if(fx != fy)  
                        {  
                            cnt[fx] += cnt[fy];  
                            pf[fx] = pf[fy] = pf[fx] | pf[fy];  
                            fa[fy] = fx;  
                        }  
                    }  
                }  
            }  
          
        vector<int> res = vector<int>(hits.size(), 0);  
        for(int i = hits.size() - 1; i >= 0; --i)  
        {  
            if(hits[i][0] == -1) continue;  
            int x = hits[i][0];  
            int y = hits[i][1];  
            int a = find(x * m + y);  
            int d = 0;  
            for(int j = 0; j < 4; ++j)  
            {  
                int nx = x + dx[j];  
                int ny = y + dy[j];  
                if(valid(nx, ny) && grid[nx][ny])  
                {  
                    int b = find(nx * m + ny);  
                    if(a == b) continue;  
                    if(!pf[b]) d += cnt[b];  
                      
                    cnt[a] += cnt[b];  
                    pf[a] = pf[b] = pf[a] | pf[b];  
                    fa[b] = a;  
                }  
            }  
            grid[x][y] = 1;  
            if(pf[a]) res[i] = d;  
        }  
        return res;  
    }  
      
};