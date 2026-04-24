# DotnetK8sApi

A small ASP.NET Core 6 Web API packaged for Kubernetes.

## Run locally

```bash
dotnet run
```

Useful endpoints:

- `GET /api/info`
- `GET /api/tasks`
- `POST /api/tasks`
- `GET /health/live`
- `GET /health/ready`
- `GET /swagger`

## Build the container

```bash
docker build -t dotnet-k8s-api:1.0.0 .
```

## Deploy to Kubernetes

For Docker Desktop Kubernetes or any cluster that can see the local image:

```bash
kubectl apply -k k8s
kubectl -n dotnet-k8s-api rollout status deployment/dotnet-k8s-api
kubectl -n dotnet-k8s-api port-forward svc/dotnet-k8s-api 8080:80
```

Then open `http://localhost:8080/swagger`.

If your cluster cannot see local Docker images, push the image to a registry and update `k8s/deployment.yaml`.
