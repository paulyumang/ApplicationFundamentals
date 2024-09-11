using Microsoft.Maui.Controls;
using ApplicationFundamentals.Services;

namespace ApplicationFundamentals.View;

public partial class StartPage : ContentPage
{
	private readonly IMyService _myService;
	public StartPage(IMyService myService)
	{
		InitializeComponent();
		_myService = myService;

		var message = _myService.GetMessage();
		MyLabel.Text = message;
	}
}