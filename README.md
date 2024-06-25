# TERRAFORM-KUBESPRAY-HELM-SOMEC#APP

### clone the kubespray repo 
```
git clone https://github.com/kubernetes-sigs/kubespray.git
cd kubespray
sudo pip install requirements.txt
```
### enter the dir and copy the credentials
```
cd kubespray/contrib/terraform/aws/
cp credentials.tfvars.example credentials.tfvars
```
### Enter the credentials with 
```
vim credentials.tfvars
```
### and fill the lines with your aws-access-key, secret-key, key-pair and region
### Then need to enter 
```
vim terraform.tfvars
```
```
#Global Vars
aws_cluster_name = "devtest"

#VPC Vars
aws_vpc_cidr_block       = "10.250.192.0/18"
aws_cidr_subnets_private = ["10.250.192.0/20", "10.250.208.0/20"]
aws_cidr_subnets_public  = ["10.250.224.0/20", "10.250.240.0/20"]

# single AZ deployment
#aws_cidr_subnets_private = ["10.250.192.0/20"]
#aws_cidr_subnets_public  = ["10.250.224.0/20"]

# 3+ AZ deployment
#aws_cidr_subnets_private = ["10.250.192.0/24","10.250.193.0/24","10.250.194.0/24","10.250.195.0/24"]
#aws_cidr_subnets_public  = ["10.250.224.0/24","10.250.225.0/24","10.250.226.0/24","10.250.227.0/24"]

#Bastion Host
aws_bastion_num  = 1
aws_bastion_size = "t2.medium"

#Kubernetes Cluster
aws_kube_master_num       = 3
aws_kube_master_size      = "t2.medium"
aws_kube_master_disk_size = 50

aws_etcd_num       = 0
aws_etcd_size      = "t3.medium"
aws_etcd_disk_size = 50

aws_kube_worker_num       = 4
aws_kube_worker_size      = "t2.medium"
aws_kube_worker_disk_size = 50

#Settings AWS ELB
aws_nlb_api_port    = 6443
k8s_secure_api_port = 6443
kube_insecure_apiserver_address = "0.0.0.0"

default_tags = {
  #  Env = "devtest"
  #  Product = "kubernetes"
}

inventory_file = "../../../inventory/hosts"
```

### and design the infrastructure

### And at last we can begin terraform commands to initialize, plan and apply our infra
```
terraform init
terraform plan -out my-test-plan -var-file=credentials.tfvars
terraform apply "my-test-plan"
```

### Now we can begin to deploy a Kubernetes cluster using Ansible
```
cd ~/kubespray
cat inventory/hosts
```
### Now load SSH keys, which were created in AWS
```
cat “” > ~/.ssh/mysomekey.pem
eval $(ssh-agent)
ssh-add -D
ssh-add ~/.ssh/mysomekey.pem
```
### now we can deploy our cluster by Ansible
```
ansible-playbook -i ./inventory/hosts ./cluster.yml -e ansible_user=armen -b --become-user=root --flush-cache
```
