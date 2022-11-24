FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /lib/fslugify
COPY . /lib/fslugify
RUN dotnet build