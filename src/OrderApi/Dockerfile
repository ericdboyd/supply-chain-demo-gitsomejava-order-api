# =============================================================================
#  Order API container
#
#  Base images are pinned by DIGEST, not by tag. This is the container
#  equivalent of the slide 20 argument — a tag is a mutable label, and
#  `9.0` today is not `9.0` next week.
#
#  Refresh the digests with: ./scripts/Update-BaseImageDigests.ps1
# =============================================================================

# NOTE: replace these digests during setup. Placeholder tags are used here so
# a fresh clone still builds; Test-DemoReadiness.ps1 warns if they are not
# pinned. Pinning them before the session is a 30-second job and it means the
# demo cannot break because upstream moved.
ARG SDK_IMAGE=mcr.microsoft.com/dotnet/sdk:9.0
ARG RUNTIME_IMAGE=mcr.microsoft.com/dotnet/aspnet:9.0

FROM ${SDK_IMAGE} AS build
WORKDIR /src

COPY OrderApi.csproj .
RUN dotnet restore OrderApi.csproj

COPY . .
RUN dotnet publish OrderApi.csproj -c Release -o /app --no-restore

FROM ${RUNTIME_IMAGE} AS final
WORKDIR /app

# Non-root. Container Apps does not require it; saying so on stage costs
# nothing and this room notices when it is missing.
USER $APP_UID

COPY --from=build /app .

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "OrderApi.dll"]
