using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User Get(int userId)
        {
            return _userDal.Get(u => u.Id == userId);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();   
        }

        public List<User> GetAllSortedASC()
        {
            List<User> unsortedUsers = _userDal.GetAll();
            User[] usersArray = GetAsArray(unsortedUsers);
            // SelectionSort
            for (int i = 0; i < usersArray.Length-1; i++)
            {
                // Find
                int minIdx = i;
                for (int j = i + 1; j < usersArray.Length; j++)
                {
                    int compareValueName = String.Compare(usersArray[j].Name, usersArray[minIdx].Name);
                    if (compareValueName == -1)
                    {
                        minIdx = j;
                    }

                    if (compareValueName == 0)
                    {
                        int compareValueSurname = String.Compare(usersArray[j].Surname, usersArray[minIdx].Surname);
                        if (compareValueSurname == -1)
                        {
                            minIdx = j;
                        }
                    }
                }

                // Swap
                User temp = usersArray[minIdx];
                usersArray[minIdx] = usersArray[i];
                usersArray[i] = temp;
            }

            return usersArray.ToList();
        }

        public List<User> GetAllSortedDESC()
        {
            List<User> unsortedUsers = _userDal.GetAll();
            User[] usersArray = GetAsArray(unsortedUsers);
            // SelectionSort
            for (int i = 0; i < usersArray.Length - 1; i++)
            {
                // Find
                int maxIdx = i;
                for (int j = i + 1; j < usersArray.Length; j++)
                {
                    int compareValueName = String.Compare(usersArray[j].Name, usersArray[maxIdx].Name);
                    if (compareValueName == 1)
                    {
                        maxIdx = j;
                    }

                    if (compareValueName == 0)
                    {
                        int compareValueSurname = String.Compare(usersArray[j].Surname, usersArray[maxIdx].Surname);
                        if (compareValueSurname == 1)
                        {
                            maxIdx = j;
                        }
                    }
                }

                // Swap
                User temp = usersArray[maxIdx];
                usersArray[maxIdx] = usersArray[i];
                usersArray[i] = temp;
            }

            return usersArray.ToList();
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public void AddUserImage(int userId, IFormFile file)
        {
            var user = _userDal.Get(u => u.Id == userId);
            user.ImagePath = AddImage(file);
        }

        public void UpdateUserImage(int userId, IFormFile file)
        {
            var user = _userDal.Get(u => u.Id == userId);
            DeleteImage(user.ImagePath);
            user.ImagePath = AddImage(file);
        }

        private User[] GetAsArray(List<User> list)
        {
            User[] array = new User[list.Count];
            int i = 0;
            foreach(User user in list)
            {
                array[i] = user;
                i++;
            }
            return array;
        }

        private string AddImage(IFormFile formFile)
        {
            string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
            string folderName = "images";

            try
            {
                if (formFile.Length > 0)
                {
                    string fileExtention = Path.GetExtension(formFile.FileName);
                    string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString("D"), fileExtention);
                    string uploadPath = Path.Combine(directory, folderName);
                    string fullPath = Path.Combine(uploadPath, fileName);
                    string filePath = Path.Combine(folderName, fileName);
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    using (FileStream fileStream = System.IO.File.Create(fullPath))
                    {
                        formFile.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return filePath.Replace("\\", "/");
                }
                else
                {
                    return "file not uploaded.";
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        private string DeleteImage(String filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return "deleted.";
            }
            return "file not deleted.";
        }
    }
}
