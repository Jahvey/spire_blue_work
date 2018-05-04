class Solution {
public:
    vector<int> findSubstring(string s, vector<string>& words) {
        vector<int>re;  
    if (s.empty() || words.empty()) return re;  
    int n = words[0].size(), length1 = s.size(), length2 = words.size();  
    map<string, int> aa;  
    for (auto x : words) ++aa[x];  
  
    for (int i = 0; i < n; ++i){  
        int l = i, r = i;//  lָ�򻬶���������ߵĵ��ʵ���ʼ�㣬 rָ�򻬶��������ұߵĵ��ʵ���ʼ��  
        map<string, int> bb;  
        while (r + n <= s.size()){  
            if (aa.count(s.substr(r, n))){//��Ч����  
                string wd = s.substr(r, n);  
                ++bb[wd];  
                r += n;  
                if (bb[wd] < aa[wd]) continue; // ��ǰ���ʸ���С��Ŀ�굥�ʸ�����r���ƣ�������Ҷ˵���(continue,������һ��ѭ���Զ�ִ��)  
  
                while (bb[wd] > aa[wd]){   //��ǰ���ʸ�������Ŀ�굥�ʸ�����ɾ������˵��ʣ�l����  
                    if (--bb[s.substr(l, n)] == 0)  
                        bb.erase(s.substr(l, n));  
                    l += n;  
                }//����һ��Ҫע����whileѭ����������if����ֱ����ǰ���ʸ�������Ŀ�굥�ʸ���������ԭ������Լ�������д�������  
  
  
                if (bb[wd] == aa[wd] && r - l == length2 * n){  //��ǰ���ʸ�������Ŀ�굥�ʸ������Ƚ�Ŀǰ����������Ŀ�굥�������Ƿ���ȣ�  
                    //�������ȣ�r���ƣ�������Ҷ˵���(������һ��ѭ���Զ�ִ��)�������ȣ�ɾ������˵��ʣ�l���ƣ�r���ƣ�������Ҷ˵���(������һ��ѭ���Զ�ִ��)��  
                    re.push_back(l);  
                    if (--bb[s.substr(l, n)] == 0)  
                        bb.erase(s.substr(l, n));  
                    l += n;  
                }  
            }  
            else {  //���������Ч����l,r������һ�����ʴ����¿�ʼ����  
                bb.clear();  
                r += n;  
                l = r;  
            }  
        }  
    }  
    return re; 
    }
};