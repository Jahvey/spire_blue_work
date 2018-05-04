class Solution {
public:  
    typedef pair<int, int> P;  
    int dx[4] = {-1, 0, 1, 0};  
    int dy[4] = {0, 1, 0, -1};  
    int used[205][205];  
    int n, m;  
    vector<vector<int>> g;  
    int id;  
      
    vector<int> hitBricks(vector<vector<int>>& grid, vector<vector<int>>& hits) {  
        vector<int> res;  
        n = grid.size();  
        m = grid[0].size();  
        g.swap(grid);  
        id = 1;  
        for(int i = 0; i < hits.size(); ++i)  
        {  
            vector<int> pos = hits[i];  
            if(g[pos[0]][pos[1]] == 0)  
            {  
                res.push_back(0);  
                continue;  
            }  
            g[pos[0]][pos[1]] = 0;  
            int cnt = 0;  
            for(int j = 0; j < 4; ++j)  
            {  
                int nx = pos[0] + dx[j];  
                int ny = pos[1] + dy[j];  
                if(valid(nx, ny) && g[nx][ny] == 1 && dfs(nx, ny))  
                {  
                    cnt += erase(nx, ny);  
                }  
                id += 1;  
            }  
            res.push_back(cnt);  
        }  
        return res;  
    }  
    bool valid(int x, int y)  
    {  
        return x >= 0 && x < n && y >= 0 && y < m;  
    }  
    bool dfs(int x, int y) //ÅÐ¶Ïgrid[x][y]ÊÇ·ñµôÂä£¬trueµôÂä£¬false²»µôÂä  
    {  
        //if(used[x][y] == id) return true;  
        if(x == 0) return false;  
        used[x][y] = id;  
        for(int i = 0; i < 4; ++i)  
        {  
            int nx = x + dx[i];  
            int ny = y + dy[i];  
            if(valid(nx, ny) && g[nx][ny] == 1 && used[nx][ny] != id)  
            {  
                //used[x][y] = id;  
                if(!dfs(nx, ny)) return false;  
            }  
        }  
        return true;  
    }  
    int erase(int x, int y)  
    {  
        int res = 1;  
        g[x][y] = 0;  
        for(int i = 0; i < 4; ++i)  
        {  
            int nx = x + dx[i];  
            int ny = y + dy[i];  
            if(valid(nx, ny) && g[nx][ny] == 1)  
            {  
                res += erase(nx, ny);   
            }  
        }  
        return res;  
    }  
};