namespace Ilumini.Services.Models
{

    public class Result<T> : Result
    {
        public T? Value { get; set; }

        public Result() { }

        public Result(ResponseModel responseModel) : base(responseModel)
        {
        }

        public Result(T value)
        {
            Value = value;
        }
    }

    public class Result
    {
        public ResponseModel? ResponseModel { get; set; }

        public bool HasResponseModel()
        {
           return ResponseModel != null;    
        }

        public Result() { }

        public Result(ResponseModel responseModel)
        {
            ResponseModel = responseModel;
        }
    }
}
