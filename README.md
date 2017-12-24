# Acceptance Test
No. | Case Name | Username | Password | Expected Result
--- | --- | --- | --- | ---
*#1* | Login Success | "ploy" | "Sck1234" | `{"status": "OK", "results": {"id": 1, "username": "ploy", "displayname": "พลอย"}}`
*#2* | Invalid Username | "ploy" | "qwerty" | `{status: "ERROR", "message": "User not found"}`
*#3* | Invalid Password | "ploy" | "qwerty" | `{status: "ERROR", "message": "User not found"}`
*#4* | Invalid Username and Password | "ploy" | "qwerty" | `{status: "ERROR", "message": "User not found"}`
*#5* | Username is required | "" | "qwerty" | `{status: "ERROR", "message": "Username and Password are required"}`
*#6* | Password is required | "ploy" | "" | `{status: "ERROR", "message": "Username and Password are required"}`
*#7* | Username and Password are required | "" | "" | `{status: "ERROR", "message": "Username and Password are required"}`

# Run Acceptance Test
Must start the API before run acceptance test by newman

## Start API
```sh
dotnet run --project API
```

## Run Newman
```sh
newman run API.AcceptanceTests/login-test-collection.json
```