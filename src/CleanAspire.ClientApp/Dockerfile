# Stage 1: Build the Blazor Client Application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["CleanAspire.ClientApp.csproj", "."]
RUN dotnet restore "CleanAspire.ClientApp.csproj"

# Copy the entire source code and build the application in Release mode
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Serve the Blazor Client Application using Nginx
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Install OpenSSL to create a self-signed certificate
RUN apk add --no-cache openssl && \
    openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /etc/ssl/private/nginx-selfsigned.key -out /etc/ssl/certs/nginx-selfsigned.crt -subj "/CN=localhost"

# Clean the default nginx content
RUN rm -rf ./*

# Copy the build output from the previous stage
COPY --from=build /app/publish/wwwroot .

# Copy the generated self-signed certificate and configure Nginx for HTTPS
COPY nginx.conf /etc/nginx/nginx.conf

# Expose port 80 for HTTP traffic and 443 for HTTPS traffic
EXPOSE 80
EXPOSE 443

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
