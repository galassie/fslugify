FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /lib/fslugify
COPY . /lib/fslugify
RUN dotnet build