# ChainBlockify
Discover ChainBlockify's lightning-fast blockchain Open-Source Data API on GitHub. Access precise data swiftly for seamless integration into your projects. Build with speed and accuracy.  Currently the app supports: BTC, ETH and DASH but more coming soon... Get started now!

#### Features:

- **Supports Multiple Blockchains:** Currently, the app supports BTC, ETH, and DASH, with more blockchain integrations coming soon.
  
- **Clean Architecture and CQRS Patterns:** ChainBlockify follows the Clean Architecture and CQRS patterns, ensuring modularity, maintainability, and scalability. Components communicate through interfaces, promoting loose coupling and ease of modification.
  
- **Highly Generic Design:** The application is crafted in an extremely generic way, enhancing flexibility and reusability. The codebase prioritizes generic solutions to accommodate diverse blockchain requirements.
  
- **Utilizes Modern Libraries:** Leveraging MediatR, AutoMapper, and Fluent Validation, ChainBlockify incorporates modern libraries to streamline development, enhance code readability, and enforce data validation.


![Screenshot 2024-04-16 011755](https://github.com/oxf/ChainBlockify/assets/9470599/55912baa-f7cf-44c1-9834-0582d8364863)
<img width="671" alt="image" src="https://github.com/oxf/ChainBlockify/assets/9470599/f62ef7a2-a392-4955-adfb-0c767bb69ff2">


# Instructions
* To use the application, please use SQL Server database and run the migrations.
* Then Populate the tables following way:
* insert into Blockchain (Name, DbTableName) values
* ('BTC',	'ChainBlockify.Domain.Entities.BlockchainInfoBtc')
* ('ETH',	'ChainBlockify.Domain.Entities.BlockchainInfoEth')
* ('DASH',	'ChainBlockify.Domain.Entities.BlockchainInfoDash')
* insert into BlockchainSource (Name) values ('Blockcypher')
* insert into BlockchainBlockchainSource (Url, BlockchainId, BlockchainSourceId, DtoName) values
* ('https://api.blockcypher.com/v1/btc/main',	1, 1,	'ChainBlockify.Application.DTOs.Blockcypher.BlockchainInfoBtcBlockcypherDto')
* ('https://api.blockcypher.com/v1/eth/main',	2,	1,	'ChainBlockify.Application.DTOs.Blockcypher.BlockchainInfoEthBlockcypherDto')
* ('https://api.blockcypher.com/v1/dash/main',	3,	1,	'ChainBlockify.Application.DTOs.Blockcypher.BlockchainInfoDashBlockcypherDto')
