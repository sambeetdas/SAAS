import { Script } from './script.model';

export interface Service {
  serviceReferenceId: string;
  controller: string;
  action: string;
  resource: string;
  methodType: string;
  status: string;
  createDate: Date;
  updateDate: Date;
  createUser: string;
  updateUser: string;
}
