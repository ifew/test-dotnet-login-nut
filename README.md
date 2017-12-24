# Acceptance Test
Username | Password | Expected Result
--- | --- | ---
ploy | Sck1234 | `{"status": "OK", "results": {"id": 1, "displayname": "ploy"}}`
ploy | qwerty | `{status: "ERROR", "message": "User not found"}`