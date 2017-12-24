# Acceptance Test
Username | Password | Expected Result
--- | --- | ---
"ploy" | "Sck1234" | `{"status": "OK", "results": {"id": 1, "displayname": "ploy"}}`
"ploy" | "qwerty" | `{status: "ERROR", "message": "User not found"}`
"" | "qwerty" | `{status: "ERROR", "message": "Username and Password are required"}`
"ploy" | "" | `{status: "ERROR", "message": "Username and Password are required"}`
"" | "" | `{status: "ERROR", "message": "Username and Password are required"}`