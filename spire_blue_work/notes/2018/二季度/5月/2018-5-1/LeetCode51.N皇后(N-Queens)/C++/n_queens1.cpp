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
            vector<string> tmp(n, string(n, '.'));              //�洢����Ҫ��Ľ⣬ע���ʼ����ʽ
            for(int i = 0; i < n; ++i) {
                tmp[i][pos[i]] = 'Q';
            }
            res.push_back(tmp);
        } else {
            for(int i = 0; i < n; ++i) {
                if(check(pos, row, i)) {                  //����Ƿ���������
                    pos[row] = i;
                    dfs(pos, n, row + 1, res);            //����
                    pos[row] = -1;                        //��ԭ��־λ
                }

            }
        }
    }

    bool check(vector<int> &pos, int row, int col) {
        for(int i = 0; i < row; ++i) {
            if(pos[i] == col || abs(row - i) == abs(col - pos[i])) //ȷ������ͬһ�����Լ�����ͬһб�Խ�����
                return false;
        }
        return true;
    }
};