#nullable disable

namespace ShoppingSystem.Captcha.Api.Entities;

public class Captcha
{    public string Key { get; set; }
    public string Value { get; private set; }
    public DateTime CreateAt { get; set; }
    public DateTime ValidUntil { get; set; }

    public string GenerateValue()
    {
        Random res = new Random(); 

        // String of alphabets  
        string str = "abcdefghijklmnopqrstuvwxyz"; 
        int size = 10; 
    
        // Initializing the empty string 
        string ran = ""; 
    
        for (int i = 0; i < size; i++) 
        { 
    
            // Selecting a index randomly 
            int x = res.Next(26); 
    
            // Appending the character at the  
            // index to the random string. 
            ran = ran + str[x]; 
        } 
        Value = ran;
        return Value;
    }
}