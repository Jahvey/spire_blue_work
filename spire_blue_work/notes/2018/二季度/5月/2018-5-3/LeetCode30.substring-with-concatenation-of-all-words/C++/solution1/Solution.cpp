class Solution {
public:
    vector<int> findSubstring(string s, vector<string>& words) {
        vector<int>re;  
    if (s.empty() || words.empty()) return re;  
    int n = words[0].size(), length1 = s.size(), length2 = words.size();  
    map<string, int> aa;  
    for (auto x : words) ++aa[x];  
  
    for (int i = 0; i < n; ++i){  
        int l = i, r = i;//  l指向滑动窗口最左边的单词的起始点， r指向滑动窗口最右边的单词的起始点  
        map<string, int> bb;  
        while (r + n <= s.size()){  
            if (aa.count(s.substr(r, n))){//有效单词  
                string wd = s.substr(r, n);  
                ++bb[wd];  
                r += n;  
                if (bb[wd] < aa[wd]) continue; // 当前单词个数小于目标单词个数，r右移，添加最右端单词(continue,跳到下一次循环自动执行)  
  
                while (bb[wd] > aa[wd]){   //当前单词个数大于目标单词个数，删除最左端单词，l右移  
                    if (--bb[s.substr(l, n)] == 0)  
                        bb.erase(s.substr(l, n));  
                    l += n;  
                }//这里一定要注意用while循环（而不是if），直到当前单词个数等于目标单词个数，具体原因可以自己跑样例写下体会下  
  
  
                if (bb[wd] == aa[wd] && r - l == length2 * n){  //当前单词个数等于目标单词个数，比较目前单词总数与目标单词总数是否相等，  
                    //如果不相等：r右移，添加最右端单词(跳到下一次循环自动执行)。如果相等：删除最左端单词，l右移；r右移，添加最右端单词(跳到下一次循环自动执行)。  
                    re.push_back(l);  
                    if (--bb[s.substr(l, n)] == 0)  
                        bb.erase(s.substr(l, n));  
                    l += n;  
                }  
            }  
            else {  //如果单词无效，则l,r跳到下一个单词处重新开始计数  
                bb.clear();  
                r += n;  
                l = r;  
            }  
        }  
    }  
    return re; 
    }
};