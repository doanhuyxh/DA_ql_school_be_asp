namespace BeApi.ViewModels
{
    public class ResponeDataViewModel
    {
        public dynamic Code { get; set; }
        public string Message { get; set; }
        public dynamic? Data { get; set; }

        public ResponeDataViewModel(ResponseStatusCode code)
        {
            Code = code;
            Message = code.GetMessage();
        }

        public ResponeDataViewModel(ResponseStatusCode code, dynamic data)
        {
            Code = code;
            Message = code.GetMessage();
            Data = data;
        }

        public ResponeDataViewModel()
        {
            Message = "";
            Code = 200;
            Data = "";
        }
    }
}