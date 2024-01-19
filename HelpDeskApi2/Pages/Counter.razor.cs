namespace HelpDeskApi2.Pages
{
    public class Counter
    {
		private int currentCount = 0;
		private List<User>? userlist = null;
		string result = "";
		private User? newuser { get; set; } = new User();
		private void IncrementCount()
		{
			currentCount++;
		}
		private async void GetUserList()
		{
			if (userlist == null)
			{
				userlist = await Http.GetFromJsonAsync<List<User>>("api/user/getuserlist");
				StateHasChanged();
			}
		}

		private async void InsertUser()
		{
			if (newuser != null)
			{
				var response = await Http.PostAsJsonAsync("api/user/insertuser", newuser);
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					newuser = new();
					result = "User successfully added.";
				}
				else
				{
					result = await response.Content.ReadAsStringAsync();
				}
				StateHasChanged();
			}
		}
	}
}
