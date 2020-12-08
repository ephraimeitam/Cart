FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

# Add NewRelic agent
#RUN apt-get update && \
#    apt-get install -y gnupg && \
#    echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list && \
#    curl -L https://download.newrelic.com/548C16BF.gpg | apt-key add - && \
#    apt-get update && \
#    apt-get install -y newrelic-netcore20-agent && \
#    rm -rf /var/lib/apt/lists/*

ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Cart.Api.dll"]
