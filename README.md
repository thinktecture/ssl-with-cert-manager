# Sample API with Let's Encrypt SSL certificate

## Pre-Requirements

- a Kubernetes Cluster
- ability to manage DNS entries for a valid domain

### Deploy in-cluster dependencies

This sample requires NGINX Ingress and cert-manager being deployed in your Kubernetes cluster. Both can be installed using Helm package manager as shown in the following sections

#### Deploy NGINX Ingress

```bash
kubectl create namespace nginx

helm repo add
helm repo update

helm install --namespace nginx

```

#### Deploy cert-manager

```bash
kubectl create namespace cert-manager

helm repo add jetstack https://charts.jetstack.io
helm repo update

helm install certmgr jetstack/cert-manager \
    --set installCRDs=true \
    --version v1.0.4 \
    --namespace cert-manager

```

### Updating DNS Configuration

Once Ingress has acquired a public IP address, an A record is required to link desired sub-domain to the public ip address. See [azure/configure-dns-zone.azcli](azure/configure-dns-zone.azcli) as example.

### Deploy the sample application

First, you have to create the target namespace

```bash
kubectl apply -f ./kubernetes/namespaces

```

Now, configure domain in corresponding yaml manifests within [kubernetes/sample](kubernetes/sample), to match your requirements.

Deploy the application

```bash
kubectl apply -f ./kubernetes/sample

```
