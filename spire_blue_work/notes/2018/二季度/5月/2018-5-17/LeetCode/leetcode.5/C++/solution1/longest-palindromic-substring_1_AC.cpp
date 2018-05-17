#include<string>
using std::string;

class Solution {
public:
    string longestPalindrome(string s) {
        int max_len=0;
        string res="";
        int ss=s.size();
        int i,j,k;
        for(i=0;i<ss;i++){
            
            
            findRes(s,i-1,i+1,max_len,res);
        }
        
        for(i=0;i+1<ss;i++){
            
            findRes(s,i,i+1,max_len,res);
            
        }
        return res;
    }
    
private:
    void findRes(string &s,int j,int k,int &max_len,string &res){
        
        
        int ss=s.size();
        while(j>=0&&k<=ss-1&&s[j]==s[k]){
            --j;
            ++k;
            
        }
        
        if(k-j-1 >max_len){
            
            
            max_len=k-j-1;
            res=s.substr(j+1,max_len);
        }
        
        
    }
};