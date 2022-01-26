FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# # update the debian based system
# RUN apt-get update && apt-get upgrade -y
# # install my dev dependacies inc sqllite and curl and unzip
# RUN apt-get install -y sqlite3
# RUN apt-get install -y libsqlite3-dev
# RUN apt-get install -y curl
# RUN apt-get install -y unzip
# # not sure why im deleting these
# RUN rm -rf /var/lib/apt/lists/*

# # add debugging in a docker tooling - install the dependencies for Visual Studio Remote Debugger
# RUN apt-get update && apt-get install -y --no-install-recommends unzip procps
# # install Visual Studio Remote Debugger
# RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l ~/vsdbg
WORKDIR /app/web

# layer and build
COPY . .
# WORKDIR /app/web
RUN dotnet restore

# layer adding linker then publish after tree shaking
FROM build AS publish
WORKDIR /app/web
RUN dotnet publish -c Release -o out

# final layer using smallest runtime available
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
RUN dotnet tool install --global dotnet-ef
WORKDIR /app/web
COPY --from=publish app/web/out ./

# expose port and execute aspnetcore app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "api.dll"]