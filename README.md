# EDI AI Processor

## Tech Stack
- ASP.NET Core 8 (LTS)
- Angular 17 (LTS)
- OpenAI Integration
- Supports file upload, EDI segment parsing, and AI-based validation

## Setup Instructions

### Backend (ASP.NET Core)
1. Navigate to `backend/`
2. Add your OpenAI API key to `appsettings.Development.json` (DO NOT commit it)
3. Run:
   ```
   dotnet restore
   dotnet run
   ```

### Frontend (Angular 17)
1. Navigate to `frontend/`
2. Run:
   ```
   npm install
   ng serve
   ```

### Notes
- Make sure your backend runs on `https://localhost:5001`
- Frontend will call `/api/EDI/upload` to process files

