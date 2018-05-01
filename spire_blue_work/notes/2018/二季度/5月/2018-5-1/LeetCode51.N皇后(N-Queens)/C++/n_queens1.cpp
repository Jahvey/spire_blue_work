class Solution {
public:
    vector<vector<string>> solveNQueens(int n) {
        vector<vector<string>> res;
        vector<int> pos(n, -1);
        dfs(pos, n, 0, res);
        return res;
    }

    void dfs(vector<int> &pos, int n, int row, vector<vector<string>> &res) {
        if(row == n) {
            vector<string> tmp(n, string(n, '.'));              //存储满足要求的解，注意初始化格式
            for(int i = 0; i < n; ++i) {
                tmp[i][pos[i]] = 'Q';
            }
            res.push_back(tmp);
        } else {
            for(int i = 0; i < n; ++i) {
                if(check(pos, row, i)) {                  //检查是否满足条件
                    pos[row] = i;
                    dfs(pos, n, row + 1, res);            //回溯
                    pos[row] = -1;                        //还原标志位
                }

            }
        }
    }

    bool check(vector<int> &pos, int row, int col) {
        for(int i = 0; i < row; ++i) {
            if(pos[i] == col || abs(row - i) == abs(col - pos[i])) //确保不在同一行列以及不在同一斜对角线上
                return false;
        }
        return true;
    }
};