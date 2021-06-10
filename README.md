# UserProject

1. git clone https://github.com/oguzhanoxel/UserProject.git
2. open a project or solution on Visual Studio
3. Set as Startup Project 'WebAPI'
4. Run 'IIS Express'.

**Contents**

1. [Created or Changed files in Layers](#created-or-changed-files-in-layers)
1. [Enpoints](#endpoints)
1. [ResponseBody](#responsebody)
1. [GetAllSortedASC](#getallsortedasc)

## Created or Changed files in Layers

- Entities
  - Abstract
    - [IEntity.cs](https://github.com/oguzhanoxel/UserProject/blob/main/Entities/Abstract/IEntity.cs)
  - Concreate
    - [Contact.cs](https://github.com/oguzhanoxel/UserProject/blob/main/Entities/Concrete/Contact.cs)
    - [User.cs](https://github.com/oguzhanoxel/UserProject/blob/main/Entities/Concrete/User.cs)
- DataAccess
  - Abstract
    - [IContactDal.cs](https://github.com/oguzhanoxel/UserProject/blob/main/DataAccess/Abstract/IContactDal.cs)
    - [IUserDal.cs](https://github.com/oguzhanoxel/UserProject/blob/main/DataAccess/Abstract/IUserDal.cs)
  - Concrete
    - InMemory
      - [InMemoryContactDal.cs](https://github.com/oguzhanoxel/UserProject/blob/main/DataAccess/Concrete/InMemory/InMemoryContactDal.cs)
      - [InMemoryUserDal.cs](https://github.com/oguzhanoxel/UserProject/blob/main/DataAccess/Concrete/InMemory/InMemoryUserDal.cs)
- Business
  - Abstract
    - [IContactService.cs](https://github.com/oguzhanoxel/UserProject/blob/main/Business/Abstract/IContactService.cs)
    - [IUserService.cs](https://github.com/oguzhanoxel/UserProject/blob/main/Business/Abstract/IUserService.cs)
  - Concrete
    - [ContactManager.cs](https://github.com/oguzhanoxel/UserProject/blob/main/Business/Concrete/ContactManager.cs)
    - [UserManager.cs](https://github.com/oguzhanoxel/UserProject/blob/main/Business/Concrete/UserManager.cs)
  - DependencyResolvers
    - Autofac
      - [AutofacBusinessModule.cs](https://github.com/oguzhanoxel/UserProject/blob/main/Business/DependencyResolvers/Autofac/AutofacBusinessModule.cs)
- WebAPI
  - Controllers
    - [ContactsController.cs](https://github.com/oguzhanoxel/UserProject/blob/main/WebAPI/Controllers/ContactsController.cs)
    - [UsersController.cs](https://github.com/oguzhanoxel/UserProject/blob/main/WebAPI/Controllers/UsersController.cs)
  - [Startup.cs](https://github.com/oguzhanoxel/UserProject/blob/main/WebAPI/Startup.cs)

## Endpoints

### Users endpoints
`/api/Users/getall`
`/api/Users/getalljson`
`/api/Users/getallsorted-asc`
`/api/Users/getallsorted-desc`

`/api/Users/get`

`/api/Users/add`
`/api/Users/update`
`/api/Users/delete`

`/api/Users/addimage`
`/api/Users/updateimage`

### Contacts endpoints
`/api/Contacts/getallbyuser`
`/api/Contacts/getall`
`/api/Contacts/get`

`/api/Contacts/add`
`/api/Contacts/delete`
`/api/Contacts/update`

## ResponseBody

### Post functions
- All Post endpoints return => string: 'added.', 'updated.', 'deleted.'

### Users

|*`/api/Users/get`*|
|:--:|
|![User-Get](https://user-images.githubusercontent.com/54795142/121514344-9392b280-c9f4-11eb-9adf-0034354edfaa.PNG)|

|*`/api/Users/getalljson`*|
|:--:|
|![User-GetAllJSON](https://user-images.githubusercontent.com/54795142/121515926-5f1ff600-c9f6-11eb-942b-09a447108e72.PNG)|

|*`/api/Users/getall`*|
|:--:|
|![User-GetAll](https://user-images.githubusercontent.com/54795142/121516251-adcd9000-c9f6-11eb-9c9e-3c607b7a2000.PNG)|

|*`/api/Users/getallsorted-asc`*|
|:--:|
|![User-GetAllASC](https://user-images.githubusercontent.com/54795142/121516320-bf169c80-c9f6-11eb-8019-6880f4ef702e.PNG)|

|*`/api/Users/getallsorted-desc`*|
|:--:|
|![User-GetAllDESC](https://user-images.githubusercontent.com/54795142/121516318-be7e0600-c9f6-11eb-822b-e85f8d69ad12.PNG)|

### Contacts

|*`/api/Contacts/getallbyuser`*|
|:--:|
|![Contact-GetAllByUser](https://user-images.githubusercontent.com/54795142/121516819-50860e80-c9f7-11eb-8f07-bff0f1b62589.PNG)|

|*`/api/Contacts/getall`*|
|:--:|
|![Contact-GetAll](https://user-images.githubusercontent.com/54795142/121516818-50860e80-c9f7-11eb-9ce7-1a9ef5cd97ef.PNG)|

|*`/api/Contacts/get`*|
|:--:|
|![Contact-Get](https://user-images.githubusercontent.com/54795142/121516816-4fed7800-c9f7-11eb-8aa9-14bf66d62bbf.PNG)|

### GetAllSortedASC

- ./UserProject/Business/Concrete/UserManager.cs

```
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
```
