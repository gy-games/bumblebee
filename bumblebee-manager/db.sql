/*
SQLyog v10.2 
MySQL - 5.1.72-log : Database - db_bumblebee
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `bumblebee_agent` */

CREATE TABLE `bumblebee_agent` (
  `agent_ip` varchar(15) NOT NULL COMMENT 'AgentIP',
  `agent_name` varchar(100) DEFAULT NULL COMMENT 'Agent名称',
  `asset` varchar(20) DEFAULT NULL COMMENT '资产号',
  `manager` varchar(20) DEFAULT NULL COMMENT '负责人',
  `main_name` varchar(50) NOT NULL COMMENT '一级分类',
  `sub_name` varchar(20) DEFAULT NULL COMMENT '二级分类',
  `os` varchar(50) DEFAULT NULL COMMENT '操作系统',
  `update_time` datetime DEFAULT NULL COMMENT '更新时间',
  PRIMARY KEY (`agent_ip`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='agent信息表';

/*Table structure for table `bumblebee_config` */

CREATE TABLE `bumblebee_config` (
  `sync_agent_url` varchar(255) DEFAULT NULL COMMENT '同步agent机器接口地址',
  `client_version` varchar(50) NOT NULL COMMENT '客户端当前版本号',
  `ignore_flag` enum('0','1') DEFAULT '0' COMMENT '忽略版本更新：0-不可忽略，1-可忽略',
  `prompt_content` varchar(255) DEFAULT NULL COMMENT '登录失败提示信息'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统配置表';

/*Table structure for table `bumblebee_group` */

CREATE TABLE `bumblebee_group` (
  `group_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '分组ID',
  `group_name` varchar(40) NOT NULL COMMENT '组名',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `create_user` varchar(40) DEFAULT NULL COMMENT '创建人',
  `desc` varchar(100) DEFAULT NULL COMMENT '描述',
  PRIMARY KEY (`group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COMMENT='分组表';

/*Table structure for table `bumblebee_user` */

CREATE TABLE `bumblebee_user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `user_name` varchar(40) NOT NULL COMMENT '用户名',
  `email` varchar(40) NOT NULL COMMENT '邮箱',
  `pwd` varchar(40) NOT NULL COMMENT '密码',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `create_user` varchar(40) DEFAULT NULL COMMENT '创建人',
  `last_login_time` datetime DEFAULT NULL COMMENT '最后登录时间',
  `group_id` int(11) DEFAULT NULL COMMENT '用户组Id',
  `is_system` tinyint(4) NOT NULL DEFAULT '0' COMMENT '是否为系统管理员：0-不是，1-是',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COMMENT='用户表';

/*Table structure for table `command_blacklist` */

CREATE TABLE `command_blacklist` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `command` varchar(200) NOT NULL COMMENT '命令',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COMMENT='命令黑名单';

/*Table structure for table `group_permission` */

CREATE TABLE `group_permission` (
  `group_id` int(11) NOT NULL COMMENT '分组ID',
  `main_name` varchar(20) NOT NULL COMMENT '机器一级分类',
  PRIMARY KEY (`group_id`,`main_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='分组授权表';

/*Table structure for table `operate_log` */

CREATE TABLE `operate_log` (
  `log_id` int(11) NOT NULL AUTO_INCREMENT COMMENT '日志ID',
  `ip` varchar(15) NOT NULL COMMENT '操作的机器IP',
  `param` varchar(255) NOT NULL COMMENT '参数',
  `result` text COMMENT '返回结果',
  `start_time` datetime DEFAULT NULL COMMENT '开始时间',
  `end_time` datetime DEFAULT NULL COMMENT '结束时间',
  `cost_time` int(11) DEFAULT NULL COMMENT '耗时（毫秒ms）',
  `operate_user` varchar(40) DEFAULT NULL COMMENT '操作人',
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8 COMMENT='操作日志表';

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;



INSERT  INTO `bumblebee_user`(`user_id`,`user_name`,`email`,`pwd`,`create_time`,`create_user`,`last_login_time`,`group_id`,`is_system`) VALUES (1,''超级管理员'',''admin@gyyx.cn'',''E10ADC3949BA59ABBE56E057F20F883E'',NOW(),''超级管理员'',NULL,NULL,1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
