# Dockerfile

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /MarvelComicList

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /MarvelComicList
COPY --from=build-env /MarvelComicList/out .

# Run the app on container startup
#ENTRYPOINT [ "dotnet", "MarvelComicList.dll" ]

# Use the following instead for Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MarvelComicList.dll