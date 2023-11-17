namespace TestStudent.Model
{
	public static class DataStore
	{
		public static List<Student> listStudent = new List<Student>()
			{
				new Student { id = 1, FirstName = "Tamilarasan", LastName = "Sadagopal", BloodGroup = "B+", PhoneNr = "999 999 9999" }
			  , new Student { id = 2, FirstName = "Elavarasi", LastName = "Sadagopal", BloodGroup = "B+", PhoneNr = "888-888-9999" }
			  , new Student { id = 3, FirstName = "KishnaKumar", LastName = "Veeramani", BloodGroup = "A+", PhoneNr = "111-222-3333" }
			  , new Student { id = 4, FirstName = "Priya", LastName = "Veeramani", BloodGroup = "A+", PhoneNr = "111-222-3333" }
			};
	}
}
