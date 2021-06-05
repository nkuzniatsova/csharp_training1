using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
        
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Nickname { get; set; } = "";
        public string Title { get; set; } = "";
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string HomePhone { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string WorkPhone { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Email { get; set; } = "";
        public string Email2 { get; set; } = "";
        public string Email3 { get; set; } = "";
        public string Homepage { get; set; } = "";
        public string Bday { get; set; } = "";
        public string Bmonth { get; set; } = "";
        public string Byear { get; set; } = "";
        public string Aday { get; set; } = "";
        public string Amonth { get; set; } = "";
        public string Ayear { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string Phone2 { get; set; } = "";
        public string Notes { get; set; } = "";
        public string AllPhones {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();
                }
            }
            set {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email + "\r\n" + Email2 + "\r\n" + Email3 + "\r\n").Trim();
                }
            }
            set{
                allEmails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname + " " + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Firstname + " " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Firstname + " " + Lastname).CompareTo(other.Firstname + " " + other.Lastname);
        }
    }
}

