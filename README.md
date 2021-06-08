# UserProject

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
`/api/Users/getall`
`/api/Users/get`

`/api/Users/add`
`/api/Users/delete`
`/api/Users/update`
