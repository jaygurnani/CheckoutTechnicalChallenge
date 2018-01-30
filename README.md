TYPE or PASTE your text # Check Technical Test
## Things built:
* WebAPI that has 6 endpoint: 
    1. Create a basket, 
    2. Get a basket, 
    3. Clear a basket, 
    4. Remove items from a basket
    5. Add items to a basket, 
    6. Update an item in the basket
* The code in the WebAPI is separated into Models, Controllers and Repositories
* Validation is done in the Controller
* All repositories now use an interface. This allows us to switch the underlying system without breaking code.
* A file is placed in the C drive - "C:\Database.json" serves as a file based storage mechanism. 
* Variables are made private only when used within the same class and are prefixed with "_".
* 2 types of unit tests are created, success unit tests and unit tests that cause failure messages on purpose.
* A postman collection is also saved in the root folder for ease of use for testing.

## Design considerations:
* GUIDs mean there is a very low chance of Id collision
* A basket has a unique Id and a list of items. Items also have unique Ids
* A Base Request object is used to help with the SDK. This takes care of the basics of setting up an HTTP Request
* Objects are used in the SDK to specify the URL and the content to be posted. This means we can easily add to the SDK by creating a new object and inheriting from the Base Request.

# Steps to Run
1. Open Visual studio as an Administrator.
2. Run the Repository and SDK Unit Tests in the Unit Test project.