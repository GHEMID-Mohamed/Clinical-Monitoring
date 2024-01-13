FROM node:18-alpine AS build-front
WORKDIR /App

COPY front ./
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-back
WORKDIR /App

COPY api ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-back /App/out .
COPY --from=build-front /App/dist ./wwwroot
ENTRYPOINT ["dotnet", "api.dll"]