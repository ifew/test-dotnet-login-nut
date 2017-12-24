# Acceptance Test
Case | Username | Password | Expected Result
--- | --- | --- | ---
Login Success | "ploy" | "Sck1234" | `{"status": "OK", "results": {"id": 1, "username": "ploy", "displayname": "พลอย"}}`
Login Failed | "ploy" | "qwerty" | `{status: "ERROR", "message": "User not found"}`
Require Username | "" | "qwerty" | `{status: "ERROR", "message": "Username and Password are required"}`
Require Password | "ploy" | "" | `{status: "ERROR", "message": "Username and Password are required"}`
Require Username and Password | "" | "" | `{status: "ERROR", "message": "Username and Password are required"}`