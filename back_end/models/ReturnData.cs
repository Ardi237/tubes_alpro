namespace back_end.models
{
    public class ReturnData
    {
        public bool Success { get; set; }     
        public string Message { get; set; }    
        public int RowsAffected { get; set; }
    }
}