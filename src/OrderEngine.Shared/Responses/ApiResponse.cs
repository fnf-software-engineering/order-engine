namespace OrderEngine.Shared.Responses;

public class ApiResponse<T>
{
	private readonly bool _success;
	private readonly string _message;
	private readonly T _data;
	private readonly DateTime _timestamp;

	public bool Success => _success;
	public string Message => _message;
	public T Data => _data;
	public DateTime Timestamp => _timestamp;

	public ApiResponse(bool success, string message, T data)
	{
		_success = success;
		_message = message;
		_data = data;
		_timestamp = DateTime.Now;
	}

	public static ApiResponse<T> Ok(T data)
	{
		return new ApiResponse<T>(true, "Success", data);
	}

	public static ApiResponse<T> Ok(T data, string message)
	{
		return new ApiResponse<T>(true, message, data);
	}

	public static ApiResponse<T> Error(string message)
	{
		return new ApiResponse<T>(false, message, default!);
	}

	public static ApiResponse<T> Error(string message, T data)
	{
		return new ApiResponse<T>(false, message, data);
	}
}


