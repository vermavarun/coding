public class Solution {
    int[]  fib = new int[31]; 
    public int Fib(int n) {
        
        fib[0] = 0;
        fib[1] = 1;
        int i  = 0;
        
        for( i=2 ; i<=n; i++ ) {
            fib[i] = fib[i-1] + fib[i-2];
        }
        return fib[n];
    }
}
