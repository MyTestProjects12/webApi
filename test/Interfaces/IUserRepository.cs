
using test.Models;

public interface IUserRepository {

	void CreateUser(User user);
	IEnumerable<User> GetAllUsers();
	void DeleteUser(int UserId);
	void UpdateUser(User user);
	User GetUserById(int Id);
}