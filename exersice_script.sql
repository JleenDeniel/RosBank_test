select distinct tbl_client.cli_fio from tbl_premium
left join tbl_contract on tbl_premium.prm_contract = tbl_contract.cnt_id
left join tbl_client on tbl_contract.cnt_client = tbl_client.cli_id
where tbl_premium.prm_type is NULL and (tbl_premium.prm_type is null or tbl_premium.prm_collected = 0);


select distinct tbl_client.cli_fio as "Client", sum(tbl_premium.prm_collected) as "Payed money" from tbl_premium
join tbl_contract on tbl_premium.prm_contract = tbl_contract.cnt_id
join tbl_client on tbl_contract.cnt_client = tbl_client.cli_id
where tbl_premium.prm_type is null
and prm_collected > 0
group by tbl_client.cli_fio;

select tbl_contract.cnt_number, tbl_premium.prm_due from tbl_premium 
left join tbl_contract on tbl_premium.prm_contract = tbl_contract.cnt_id
where tbl_premium.prm_type is null
and (tbl_contract.cnt_date between "2018-01-01" and "2018-12-31")
and (tbl_premium.prm_collected is null or tbl_premium.prm_collected = 0);


delete from tbl_premium 
where prm_id in (
select max(tbl_premium.prm_id) from tbl_premium 
join tbl_contract on tbl_premium.prm_contract = tbl_contract.cnt_id
where tbl_contract.cnt_number in ("A", "B", "C") and tbl_premium.prm_type = "R"
);



