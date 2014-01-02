(*
 * Copyright (c) 2012--2013 MSR-INRIA Joint Center. All rights reserved.
 * 
 * This code is distributed under the terms for the CeCILL-B (version 1)
 * license.
 * 
 * You should have received a copy of the CeCILL-B (version 1) license
 * along with this program.  If not, see:
 * 
 *   http://www.cecill.info/licences/Licence_CeCILL-B_V1-en.txt
 *)

module SessionDB

open TLSInfo
open Date

type StorableSession = SessionInfo * PRF.masterSecret
type SessionIndex = sessionID * Role * Cert.hint

#if ideal
type entry = sessionID * Role * Cert.hint * StorableSession
type t = entry list
#else
type t
#endif

val create: config -> t
val select: t -> sessionID -> Role -> Cert.hint -> StorableSession option
val insert: t -> sessionID -> Role -> Cert.hint -> StorableSession -> t
val remove: t -> sessionID -> Role -> Cert.hint -> t

val getAllStoredIDs: t -> SessionIndex list
