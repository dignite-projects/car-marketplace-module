import type { AuditedEntityDto, ExtensibleEntityDto, PagedResultRequestDto } from '@abp/ng.core';
import type { DirectoryMovePosition } from './directory-move-position.enum';

export interface CreateDirectoryInput {
  containerName: string;
  name: string;
  parentId?: string;
}

export interface DirectoryDescriptorDto extends AuditedEntityDto<string> {
  containerName?: string;
  name?: string;
  parentId?: string;
}

export interface DirectoryDescriptorInfoDto extends ExtensibleEntityDto<string> {
  containerName?: string;
  name?: string;
  parentId?: string;
  hasChildren: boolean;
  children: DirectoryDescriptorInfoDto[];
}

export interface GetDirectoriesInput extends PagedResultRequestDto {
  creatorId?: string;
  containerName: string;
  parentId?: string;
}

export interface MoveDirectoryInput {
  targetId?: string;
  position: DirectoryMovePosition;
}

export interface UpdateDirectoryInput {
  name: string;
}
