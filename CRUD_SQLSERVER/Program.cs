/*
  In this program i have created table in sql server
    using:-
        CREATE TABLE Contact
        (
	        ContactId UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	        AddressId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Address(AddressId) ON DELETE CASCADE,
	        FirstName VARCHAR (75),
	        LastName VARCHAR(75),
	        PhoneNumber VARCHAR(15),
	
        )
        CREATE TABLE Address
        (
	        AddressId UNIQUEIDENTIFIER PRIMARY KEY,
	        Street VARCHAR (110),
	        City VARCHAR(40),
	        PostalCode int,
	        Note VARCHAR(MAX)
        )
        -------------------------------------
  Note: I have done error handling in this program
*/

using System;
using System.Data.SqlClient;

namespace ContactDb
{
    public class ContactDb
    {
        //create data
        public void createRecord()
        {
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Street:");
            string street = Console.ReadLine();
            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Postal Code:");
            int postalCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter note:");
            string note = Console.ReadLine();
            Console.WriteLine("Firstname:" +firstName+"\tLastname:"+lastName+"\tPhone Number"+phoneNumber);
            Console.WriteLine("street:"+ street+"\tcity:"+city+"\tPostal Code:"+postalCode+"\tNote:"+note);
            //sql connection
            Console.WriteLine("Getting Connection ...");

            var datasource = @"DESKTOP-DNJ6EM7";//your server
            var database = "ContactDb"; //your database name


            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            
            SqlCommand cmd = new SqlCommand((@"
                                                BEGIN TRANSACTION
	                                                DECLARE @AddressID uniqueidentifier= NEWID()
	                                                INSERT INTO Address(AddressID,Street,City,PostalCode,Note) values(@AddressID,@street,@city,@postalCode,@note)
	                                                INSERT INTO Contact(ContactId,AddressID,FirstName, LastName, PhoneNumber) values(default,@AddressID,@firstName,@lastName,@phoneNumber)
	                                                print @AddressID
                                                COMMIT
                                                      "), conn);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@street", street);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@postalCode", postalCode);
            cmd.Parameters.AddWithValue("@note", note);
            var myreader = cmd.ExecuteReader();
            conn.Close();
            
        }
        //view all records
        public void viewAllRecords()
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"DESKTOP-DNJ6EM7";//your server
            var database = "ContactDb"; //your database name


            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }


            string displayQuery = "Select * from Contact c, Address a where c.AddressId=a.AddressId";
            SqlCommand cmd = new SqlCommand(displayQuery, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(
                    "First Name:"+dr.GetValue(2).ToString()+"\n"+
                    "Last Name:" + dr.GetValue(3).ToString()+"\n"+
                    "Phone Number:" + dr.GetValue(4).ToString()+"\n"+
                    "Street:" + dr.GetValue(6).ToString()+"\n"+
                    "City:" + dr.GetValue(7).ToString()+"\n"+
                    "Postal Code:" + dr.GetValue(8).ToString()+"\n"+
                    "Note:" + dr.GetValue(9).ToString()+"\n"+
                    "-------------------------------------------------\n"+
                    "-------------------------------------------------\n"+
                    "-------------------------------------------------\n"
                    );
            }
            dr.Close();
            conn.Close();
        }
        //View Details By First Name
        public void viewByFirstName()
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"DESKTOP-DNJ6EM7";//your server
            var database = "ContactDb"; //your database name


            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            string displayQuery = "Select * from Contact c, Address a where c.firstName='"+firstName+"'";
            SqlCommand cmd = new SqlCommand(displayQuery, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(
                    "First Name:" + dr.GetValue(2).ToString() + "\n" +
                    "Last Name:" + dr.GetValue(3).ToString() + "\n" +
                    "Phone Number:" + dr.GetValue(4).ToString() + "\n" +
                    "Street:" + dr.GetValue(6).ToString() + "\n" +
                    "City:" + dr.GetValue(7).ToString() + "\n" +
                    "Postal Code:" + dr.GetValue(8).ToString() + "\n" +
                    "Note:" + dr.GetValue(9).ToString() + "\n" +
                    "-------------------------------------------------\n" +
                    "-------------------------------------------------\n" +
                    "-------------------------------------------------\n"
                    );
            }
            dr.Close();
            conn.Close();
        }
        //delete by Phone Number
        public void delete()
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"DESKTOP-DNJ6EM7";//your server
            var database = "ContactDb"; //your database name


            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.WriteLine("Enter Phone Number:");
            string phoneNumber = Console.ReadLine();
            SqlCommand cmd = new SqlCommand((@"
            DELETE a
	            FROM Contact c
	            JOIN Address a ON a.addressId=c.addressId
	            WHERE
	            c.PhoneNumber=@phoneNumber 
	            AND c.AddressId=a.AddressId
            "), conn);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            var myreader = cmd.ExecuteReader();
            conn.Close();
        }

        //Update Data By Phone Number
        public void update()
        {
            Console.WriteLine("Getting Connection ...");

            var datasource = @"DESKTOP-DNJ6EM7";//your server
            var database = "ContactDb"; //your database name


            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.WriteLine("Enter Phone Number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Please Enter Updated List.......");
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            string newPhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Street:");
            string street = Console.ReadLine();
            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Postal Code:");
            int postalCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter note:");
            string note = Console.ReadLine();
            SqlCommand cmd = new SqlCommand((@"
                                     BEGIN TRANSACTION;
	                                    UPDATE Contact 
                                        SET Contact.FirstName = @firstName
	                                    ,Contact.LastName =  @lastName
                                        ,Contact.PhoneNumber = @newPhoneNumber
	                                    FROM Contact T1, Address T2
	                                    WHERE T1.AddressId = T2.AddressId
	                                    and T1.PhoneNumber = @phoneNumber;

	                                    UPDATE Address
	                                    SET Address.Street = @street
                                        ,Address.City = @city
                                        ,Address.Note = @note
                                        ,Address.PostalCode =@postalCode
	                                    FROM Contact T1, Address T2
	                                    WHERE T1.AddressId = T2.AddressId
	                                    and T1.PhoneNumber = @newPhoneNumber;
                                    COMMIT;
            "), conn);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@newPhoneNumber", newPhoneNumber);
            cmd.Parameters.AddWithValue("@street", street);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@postalCode", postalCode);
            cmd.Parameters.AddWithValue("@note", note);
            var myreader = cmd.ExecuteReader();
            conn.Close();
        }
        //For Operating CRUD operation
        public void operation()
        {
            Console.WriteLine("Please make your selection");
            Console.WriteLine("1. Create Records");
            Console.WriteLine("2. View All Records.");
            Console.WriteLine("3. View By First Name.");
            Console.WriteLine("4. Update Record By Phone Number.");
            Console.WriteLine("5. Delete Records By Phone Number.");

           
            #pragma warning disable CS8604 // Possible null reference argument.
            int Selection = int.Parse(Console.ReadLine());
            #pragma warning restore CS8604 // Possible null reference argument.
            
            switch (Selection)
            {
                case 1:
                    createRecord();
                    break;
                case 2:
                    viewAllRecords();
                    break ;
                case 3:
                    viewByFirstName();
                    break;
                case 4:
                    update();
                    break;
                case 5:
                    delete();
                    break;
                default:
                    Console.WriteLine("Unknow Choice");
                    break;
            }
            

        }
        static void Main(string[] arg)
        {
            ContactDb db = new ContactDb();
            db.operation();

        }
    }
}