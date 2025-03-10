# 🎬 AzureVideoIndexer

AzureVideoIndexer is a .NET 8 console application that analyzes video files using Azure Video Indexer and logs detailed insights.

## 🚀 Features

- Analyzes video files using Azure Video Indexer.
- Logs detailed insights, including transcript, keywords, faces, and video metadata.

## 📦 Prerequisites

- .NET 8 SDK
- Azure Video Indexer account and credentials

## 🛠️ Setup

1. **Clone the repository**:

   ```bash
   gh repo clone AlessioCabianca/azure-video-indexer
   cd azure-video-indexer/src
   ```

2. **Initialize user secrets**:

   ```bash
   dotnet user-secrets init
   ```

3. **Set Azure Video Indexer credentials**:

   ```bash
   dotnet user-secrets set "VideoIndexer:AccountId" "your_account_id"
   dotnet user-secrets set "VideoIndexer:ApiKey" "your_api_key"
   dotnet user-secrets set "VideoIndexer:Location" "your_location"
   ```

   Replace `"your_account_id"`, `"your_api_key"` and `"your_location"` with your actual Azure Video Indexer credentials.

## 💻 Usage

1. **Build the application**:

   ```bash
   dotnet build
   ```

2. **Run the application**:

   ```bash
   dotnet run
   ```

3. **The application will analyze the input video and log the insights to the console.**

## 📚 Acknowledgements

This project utilizes the following services:

- [Azure Video Indexer](https://azure.microsoft.com/it-it/products/ai-video-indexer) for video analysis.
- .NET 8 for application development.
