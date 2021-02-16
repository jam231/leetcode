using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
public class FreqStack {
    IList<Stack<int>> StackPerFrequency { get; set;}
    IDictionary<int, int> ElementFrequency {get; set;}
    int MaxFrequency { get; set;}
    
    /* 
        Space complexity: O(n) where n
        Time complexity:
            Push(x) - O(1)
            Pop()   - O(1) 
    */
    public FreqStack() {
        StackPerFrequency = new List<Stack<int>>();
        ElementFrequency = new Dictionary<int, int>();
    }
    
    /*
        Time complexity: O(1)
    */
    public void Push(int x) {
        var freq = 1;
        if(!ElementFrequency.ContainsKey(x)) {
            ElementFrequency.Add(x, freq);
        } 
        else {
            freq = ElementFrequency[x] + 1;
            ElementFrequency[x] = freq;
        }
        
        if(StackPerFrequency.Count < freq) {
            StackPerFrequency.Add(new Stack<int>());
        }        
        StackPerFrequency[freq - 1].Push(x);
    }
    
    public int Pop() {
        var maxFrequency = StackPerFrequency.Count - 1;
        var maxFrequencyStack = StackPerFrequency[maxFrequency];
        var item = maxFrequencyStack.Pop();
        
        if(!maxFrequencyStack.Any()) {
            StackPerFrequency.RemoveAt(maxFrequency);
        }
    
        ElementFrequency[item]--;
        if(ElementFrequency[item] == 0) {
            ElementFrequency.Remove(item);
        }
        
        return item;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 */
}
